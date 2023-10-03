namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Creators");
            XmlSerializer serializer = new XmlSerializer(typeof(XMLImportCreatorDto[]), xmlRoot);

            StringReader stringReader = new StringReader(xmlString);
            XMLImportCreatorDto[] importCreatorDtos = (XMLImportCreatorDto[])serializer.Deserialize(stringReader);
            ICollection<Creator> validCreators = new HashSet<Creator>();

            foreach (var creatorDto in importCreatorDtos)
            {
                if (!IsValid(creatorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Creator c = new Creator()
                {
                    FirstName = creatorDto.FirstName,
                    LastName = creatorDto.LastName,
                };

                foreach (var boardgameDto in creatorDto.Boardgames)
                {
                    if (!IsValid(boardgameDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Boardgame b = new Boardgame()
                    {
                        Name = boardgameDto.Name,
                        Rating = boardgameDto.Rating,
                        YearPublished = boardgameDto.YearPublished,
                        CategoryType = (CategoryType)boardgameDto.CategoryType,
                        Mechanics = boardgameDto.Mechanics,
                    };

                    c.Boardgames.Add(b);
                }

                validCreators.Add(c);
                sb.AppendLine(string.Format(SuccessfullyImportedCreator, c.FirstName, c.LastName, c.Boardgames.Count));
            }
            context.Creators.AddRange(validCreators);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            JSONImportSellerDto[] importSellerDtos = JsonConvert.DeserializeObject<JSONImportSellerDto[]>(jsonString);
            ICollection<int> validIds = context.Boardgames.Select(x => x.Id).ToArray();
            ICollection<Seller> validSellers= new HashSet<Seller>();

            foreach (var sellerDto in importSellerDtos)
            {
                if (!IsValid(sellerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Seller s = new Seller()
                {
                    Name= sellerDto.Name,
                    Address= sellerDto.Address,
                    Country= sellerDto.Country,
                    Website= sellerDto.Website,
                };

                foreach (var boardgameId in sellerDto.Boardgames.Distinct())
                {
                    if (!validIds.Contains(boardgameId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    BoardgameSeller boardgameSeller = new BoardgameSeller()
                    {
                        Seller = s,
                        BoardgameId = boardgameId
                    };
                    s.BoardgamesSellers.Add(boardgameSeller);
                }
                validSellers.Add(s);
                sb.AppendLine(string.Format(SuccessfullyImportedSeller,s.Name,s.BoardgamesSellers.Count));
            }

            context.Sellers.AddRange(validSellers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
