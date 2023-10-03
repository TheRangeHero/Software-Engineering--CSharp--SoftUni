namespace Footballers.DataProcessor
{
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Coaches");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportXMLCoacheDto[]), xmlRoot);

            using StringReader writer = new StringReader(xmlString);
            ImportXMLCoacheDto[] coacheDtos = (ImportXMLCoacheDto[])serializer.Deserialize(writer);

            ICollection<Coach> validCoaches = new List<Coach>();

            foreach (var coach in coacheDtos)
            {
                if (!IsValid(coach))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                string nationality = coach.Nationality;
                bool isNatValid = string.IsNullOrEmpty(nationality);

                if (isNatValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Coach c = new Coach()
                {
                    Name = coach.Name,
                    Nationality = coach.Nationality
                };


                foreach (var footballerDto in coach.Footballers)
                {
                    if (!IsValid(footballerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime startDate;
                    bool isStartDateValid = DateTime.TryParseExact(footballerDto.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);
                    if (!isStartDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime endDate;
                    bool isEndDatevalid = DateTime.TryParseExact(footballerDto.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate);
                    if (!isEndDatevalid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (startDate >= endDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Footballer f = new Footballer()
                    {
                        Name = footballerDto.Name,
                        ContractStartDate = startDate,
                        ContractEndDate = endDate,
                        BestSkillType = (BestSkillType)footballerDto.BestSkillType,
                        PositionType = (PositionType)footballerDto.PositionType
                    };

                    c.Footballers.Add(f);
                }

                validCoaches.Add(c);
                sb.AppendLine(String.Format(SuccessfullyImportedCoach,c.Name,c.Footballers.Count));
            }
            context.Coaches.AddRange(validCoaches);
            context.SaveChanges();
            return sb.ToString().TrimEnd();

        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportJsonTeams[] teamDtos = JsonConvert.DeserializeObject<ImportJsonTeams[]>(jsonString);

            ICollection<Team> validTeams = new List<Team>();
            ICollection<int> ValidFootballerId = context.Footballers
                .Select(f => f.Id)
                .ToArray();
            foreach (var team in teamDtos)
            {
                if (!IsValid(team))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                Team t = new Team()
                {
                    Name = team.Name,
                    Nationality = team.Nationality,
                    Trophies = team.Trophies,
                };

                if (t.Trophies==0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                foreach (var footballerId in team.Footballers.Distinct())
                {
                    if (!ValidFootballerId.Contains(footballerId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    TeamFootballer tf = new TeamFootballer()
                    {
                        Team = t,
                        FootballerId = footballerId,
                    };

                    t.TeamsFootballers.Add(tf);
                }

                validTeams.Add(t);
                sb.AppendLine(string.Format(SuccessfullyImportedTeam,t.Name,t.TeamsFootballers.Count));
            }

            context.Teams.AddRange(validTeams);
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
