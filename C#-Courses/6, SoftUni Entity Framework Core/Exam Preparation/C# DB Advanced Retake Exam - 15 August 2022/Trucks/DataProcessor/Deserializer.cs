namespace Trucks.DataProcessor;

using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using Castle.Core.Internal;
using Data;
using Data.Models;
using Data.Models.Enums;
using ImportDto;
using Newtonsoft.Json;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data!";

    private const string SuccessfullyImportedDespatcher
        = "Successfully imported despatcher - {0} with {1} trucks.";

    private const string SuccessfullyImportedClient
        = "Successfully imported client - {0} with {1} trucks.";

    public static string ImportDespatcher(TrucksContext context, string xmlString)
    {
        StringBuilder sb = new StringBuilder();

        XmlRootAttribute xmlRoot = new XmlRootAttribute("Despatchers");
        XmlSerializer serializer = new XmlSerializer(typeof(ImportDispatcherXMLDto[]), xmlRoot);

        using StringReader reader = new StringReader(xmlString);
        ImportDispatcherXMLDto[] despatcherXMLDtos = (ImportDispatcherXMLDto[])serializer.Deserialize(reader);


        List<Despatcher> despatchers = new List<Despatcher>();
        foreach (var despatcherDto in despatcherXMLDtos)
        {
            if (!IsValid(despatcherDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            string position = despatcherDto.Position;

            if (string.IsNullOrEmpty(position))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            ICollection<Truck> validTrucks = new HashSet<Truck>();
            foreach (var truckDto in despatcherDto.Trucks)
            {
                if (!IsValid(truckDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Truck tr = new Truck()
                {
                    RegistrationNumber = truckDto.RegistrationNumber,
                    VinNumber = truckDto.VinNumber,
                    TankCapacity = truckDto.TankCapacity,
                    CargoCapacity = truckDto.CargoCapacity,
                    CategoryType = (CategoryType)truckDto.CategoryType,
                    MakeType = (MakeType)truckDto.MakeType
                };

                validTrucks.Add(tr);
            }

            Despatcher despatcher = new Despatcher()
            {
                Name = despatcherDto.Name,
                Position = position,
                Trucks = validTrucks
            };

            despatchers.Add(despatcher);
            sb.AppendLine(string.Format(SuccessfullyImportedDespatcher, despatcher.Name, despatcher.Trucks.Count));
        }

        context.Despatchers.AddRange(despatchers);
        context.SaveChanges();

        return sb.ToString().TrimEnd();
    }
    public static string ImportClient(TrucksContext context, string jsonString)
    {
        StringBuilder sb = new StringBuilder();

        ImportJSONClientDto[] clientDtos = JsonConvert.DeserializeObject<ImportJSONClientDto[]>(jsonString);
        ICollection<int> validIds = context.Trucks.Select(x => x.Id).ToArray();

        List<Client> clients = new List<Client>();

        foreach (var clientDto in clientDtos)
        {
            if (!IsValid(clientDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            if (clientDto.Type == "usual")
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }


            Client client = new Client()
            {
                Name = clientDto.Name,
                Nationality = clientDto.Nationality,
                Type = clientDto.Type,
            };


            foreach (int truckId in clientDto.Trucks.Distinct())
            {
                if (!validIds.Contains(truckId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                ClientTruck ct = new ClientTruck()
                {
                    Client = client,
                    TruckId = truckId,
                };
                client.ClientsTrucks.Add(ct);

                
            }

            clients.Add(client);
            sb.AppendLine(string.Format(SuccessfullyImportedClient, client.Name, client.ClientsTrucks.Count));
        }
        context.Clients.AddRange(clients);
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