namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";



        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var minimumTime = new TimeSpan(1, 0, 0);
            var validGenres = new string[] { "Drama", "Comedy", "Romance", "Musical" };



            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
            XmlSerializer serializer = new XmlSerializer(typeof(XMLImportPlayDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);
            XMLImportPlayDto[] importPlayDtos = (XMLImportPlayDto[])serializer.Deserialize(reader);
            ICollection<Play> validPlays = new HashSet<Play>();

            foreach (var playDto in importPlayDtos)
            {
                TimeSpan currentDtoTime;
                bool isParsed = TimeSpan.TryParseExact(playDto.Duration, "c", CultureInfo.InvariantCulture, out currentDtoTime);
                if (!isParsed)
                {
                    continue;
                }

                currentDtoTime = TimeSpan.ParseExact(playDto.Duration, "c", CultureInfo.InvariantCulture);

                if  (!IsValid(playDto) 
                    || (currentDtoTime < minimumTime) 
                    || !validGenres.Contains(playDto.Genre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Play p = new Play()
                {
                    Title = playDto.Title,
                    Duration = currentDtoTime,
                    Rating = playDto.Rating,
                    Genre = (Genre)Enum.Parse(typeof(Genre), playDto.Genre),
                    Description= playDto.Description,
                    Screenwriter= playDto.Screenwriter,
                };

                validPlays.Add(p);
                sb.AppendLine(string.Format(SuccessfulImportPlay, p.Title, p.Genre, p.Rating));
            }
            context.Plays.AddRange(validPlays);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Casts"); 
            XmlSerializer serializer = new XmlSerializer(typeof(XMLImportCastDto[]), xmlRoot);

           using StringReader reader = new StringReader(xmlString);
            XMLImportCastDto[] importCastDtos = (XMLImportCastDto[])serializer.Deserialize(reader);
            ICollection<Cast> validCasts= new HashSet<Cast>();

            foreach (var castDto in importCastDtos)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Cast c = new Cast()
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId,
                };

                validCasts.Add(c);
                var isMainActor = castDto.IsMainCharacter == true ? "main" : "lesser";
                sb.AppendLine(string.Format(SuccessfulImportActor, c.FullName, isMainActor));
            }
            context.Casts.AddRange(validCasts);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            JSONImportTheatreDto[] importTheatreDtos = JsonConvert.DeserializeObject<JSONImportTheatreDto[]>(jsonString);
            ICollection<Theatre> validTheatres = new HashSet<Theatre>();

            foreach (var theatreDto in importTheatreDtos)
            {
                if (!IsValid(theatreDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre t = new Theatre()
                {
                    Name= theatreDto.Name,
                    NumberOfHalls = theatreDto.NumberOfHalls,
                    Director= theatreDto.Director,

                };

                foreach (var ticketDto in theatreDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket ticket = new Ticket()
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId,
                    };

                    t.Tickets.Add(ticket);

                }

                validTheatres.Add(t);
                sb.AppendLine(string.Format(SuccessfulImportTheatre, t.Name, t.Tickets.Count));
            }
            context.Theatres.AddRange(validTheatres);
            context.SaveChanges();
            return sb.ToString().TrimEnd();

        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
