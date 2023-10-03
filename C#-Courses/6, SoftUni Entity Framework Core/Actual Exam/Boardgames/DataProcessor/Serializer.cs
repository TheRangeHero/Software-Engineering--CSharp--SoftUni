namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Creators");
            XmlSerializer serialize = new XmlSerializer(typeof(XMLExportCreatorDto[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter stringWriter = new StringWriter(sb);

            XMLExportCreatorDto[] exportCreatorDtos = context.Creators
                .Where(c => c.Boardgames.Count() > 0)
                .ToArray()
                .Select(c => new XMLExportCreatorDto
                {
                    BoardgamesCount = c.Boardgames.Count(),
                    CreatorName = $"{c.FirstName} {c.LastName}",
                    Boardgames = c.Boardgames.Select(b => new XMLExportBoardgameDto
                    {
                        BoardgameName = b.Name,
                        BoardgameYearPublished = b.YearPublished,
                    })
                    .OrderBy(b => b.BoardgameName)
                    .ToArray()
                })
                .OrderByDescending(c => c.Boardgames.Count())
                .ThenBy(c => c.CreatorName)
                .ToArray();

            serialize.Serialize(stringWriter, exportCreatorDtos, namespaces);
            return sb.ToString().TrimEnd();
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {

            var sellers = context.Sellers
      .Where(s => s.BoardgamesSellers.Count() > 0 &&
      s.BoardgamesSellers.Any(b => b.Boardgame.YearPublished >= year &&
      s.BoardgamesSellers.Any(b => b.Boardgame.Rating <= rating)))
      .Select(s => new
      {
          Name = s.Name,
          Website = s.Website,
          Boardgames = s.BoardgamesSellers.Where(b => b.Boardgame.YearPublished >= year && b.Boardgame.Rating <= rating)
          .Select(b => new
          {
              Name = b.Boardgame.Name,
              Rating = Math.Round(b.Boardgame.Rating, 2),
              Mechanics = b.Boardgame.Mechanics,
              Category = b.Boardgame.CategoryType.ToString(),
          })
          .OrderByDescending(b => b.Rating)
          .ThenBy(b => b.Name)
          .ToArray()
      })
      .OrderByDescending(s => s.Boardgames.Length)
      .ThenBy(s => s.Name)
      .Take(5)
      .ToArray();

            return JsonConvert.SerializeObject(sellers, Formatting.Indented);

        }
    }
}