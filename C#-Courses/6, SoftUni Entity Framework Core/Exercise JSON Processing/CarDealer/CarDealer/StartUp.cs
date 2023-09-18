using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Globalization;

namespace CarDealer;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new CarDealerContext();

        //string inputJson = File.ReadAllText(@"../../../Datasets/sales.json");

        string result = GetSalesWithAppliedDiscount(context);
        Console.WriteLine(result);
    }

    public static string ImportSuppliers(CarDealerContext context, string inputJson)
    {
        IMapper mapper = CreateMapper();

        ImportSupplierDTO[] importSupplierDTOs = JsonConvert.DeserializeObject<ImportSupplierDTO[]>(inputJson);

        Supplier[] suppliers = mapper.Map<Supplier[]>(importSupplierDTOs);

        context.Suppliers.AddRange(suppliers);
        context.SaveChanges();

        return $"Successfully imported {suppliers.Length}.";
    }
    public static string ImportParts(CarDealerContext context, string inputJson)
    {
        IMapper mapper = CreateMapper();

        ImportPartDTO[] importPartDTOs = JsonConvert.DeserializeObject<ImportPartDTO[]>(inputJson);

        var existingSupplier = context.Suppliers.Select(s => s.Id).ToArray();

        ICollection<Part> parts = new List<Part>();
        foreach (var item in importPartDTOs)
        {
            if (!existingSupplier.Contains(item.SupplierId))
            {
                continue;
            }

            Part part = mapper.Map<Part>(item);
            parts.Add(part);
        }

        context.Parts.AddRange(parts);
        context.SaveChanges();

        return $"Successfully imported {parts.Count}.";
    }
    public static string ImportCars(CarDealerContext context, string inputJson)
    {
        //IMapper mapper = CreateMapper();

        //ImportCarDTO[] importCarDTOs = JsonConvert.DeserializeObject<ImportCarDTO[]>(inputJson);

        //Car[] cars = mapper.Map<Car[]>(importCarDTOs);

        //context.Cars.AddRange(cars);
        //context.SaveChanges();

        //return $"Successfully imported {cars.Length}.";

        ImportCarDTO[] carsAndPartsDTO = JsonConvert.DeserializeObject<ImportCarDTO[]>(inputJson);

        List<PartCar> parts = new List<PartCar>();
        List<Car> cars = new List<Car>();

        foreach (var dto in carsAndPartsDTO)
        {
            Car car = new Car()
            {
                Make = dto.Make,
                Model = dto.Model,
                TraveledDistance = dto.TraveledDistance
            };
            cars.Add(car);

            foreach (var part in dto.PartsId.Distinct())
            {
                PartCar partCar = new PartCar()
                {
                    Car = car,
                    PartId = part,
                };
                parts.Add(partCar);
            }
        }

        context.Cars.AddRange(cars);
        context.PartsCars.AddRange(parts);
        context.SaveChanges();
        return $"Successfully imported {cars.Count}.";
    }
    public static string ImportCustomers(CarDealerContext context, string inputJson)
    {
        IMapper mapper = CreateMapper();

        ImportCustomerDTO[] importCustomerDTOs = JsonConvert.DeserializeObject<ImportCustomerDTO[]>(inputJson);

        Customer[] customers = mapper.Map<Customer[]>(importCustomerDTOs);

        context.Customers.AddRange(customers);
        context.SaveChanges();

        return $"Successfully imported {customers.Length}.";
    }
    public static string ImportSales(CarDealerContext context, string inputJson)
    {
        IMapper mapper = CreateMapper();

        ImportSalesDTO[] importSalesDTOs = JsonConvert.DeserializeObject<ImportSalesDTO[]>(inputJson);
        ICollection<Sale> validSales = new List<Sale>();
        foreach (var item in importSalesDTOs)
        {

            Sale sale = mapper.Map<Sale>(item);
            validSales.Add(sale);
        }

        context.Sales.AddRange(validSales);
        context.SaveChanges();

        return $"Successfully imported {validSales.Count}.";
    }


    public static string GetOrderedCustomers(CarDealerContext context)
    {
        var customers = context.Customers
            .OrderBy(c => c.BirthDate)
            .ThenBy(c => c.IsYoungDriver == true)
            .Select(c => new
            {
                c.Name,
                BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                c.IsYoungDriver
            })
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(customers, Formatting.Indented);
    }
    public static string GetCarsFromMakeToyota(CarDealerContext context)
    {
        var cars = context.Cars
            .Where(c => c.Make == "Toyota")
            .OrderBy(c => c.Model)
            .ThenByDescending(c => c.TraveledDistance)
            .Select(c => new
            {
                c.Id,
                c.Make,
                c.Model,
                c.TraveledDistance
            })
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(cars, Formatting.Indented);
    }
    public static string GetLocalSuppliers(CarDealerContext context)
    {
        var suppliers = context.Suppliers
            .Where(s => s.IsImporter == false)
            .Select(s => new
            {
                s.Id,
                s.Name,
                PartsCount = s.Parts.Count
            })
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
    }
    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
    {
        var cars = context.Cars
            .Select(c => new
            {
                car = new
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                },
                parts = c.PartsCars.Select(p => new
                {
                    Name = p.Part.Name,
                    Price = p.Part.Price.ToString("f2")
                })
                .ToArray()
            })
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(cars, Formatting.Indented);
    }
    public static string GetTotalSalesByCustomer(CarDealerContext context)
    {
        IContractResolver contractResolver = ConfigureCamelCaseNaming();

        var customersWithCars = context.Customers
               .Where(c => c.Sales.Count > 0)
               .Select(c => new
               {
                   fullName = c.Name,
                   boughtCars = c.Sales.Count,
                   //spentMoney = 0,
                   CARS = c.Sales
                       .Select(s => new
                       {
                           carName = s.Car.Model,
                           PARTS = s.Car.PartsCars
                               .Select(pc => new
                               {
                                   partName = pc.Part.Name,
                                   PRICES = pc.Part.Price,
                               })
                               .ToArray()
                               .Sum(p => p.PRICES)
                       })
                       .ToArray(),
               })
               .ToArray();

        var data = customersWithCars
            .Select(c => new
            {
                fullName = c.fullName,
                boughtCars = c.boughtCars,
                spentMoney = c.CARS.Sum(c => c.PARTS)
            })
            .OrderByDescending(x => x.spentMoney)
            .ThenByDescending(x => x.boughtCars)
            .ToArray();

        return JsonConvert.SerializeObject(
                data,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver,
                    NullValueHandling = NullValueHandling.Ignore,
                });
    }
    public static string GetSalesWithAppliedDiscount(CarDealerContext context)
    {
        IContractResolver contractResolver = ConfigureCamelCaseNaming();

        var salesDiscount = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    customerName = s.Customer.Name,
                    discount = String.Format("{0:F2}", s.Discount),
                    price = String.Format("{0:F2}",
                        s.Car.PartsCars.Sum(pc => pc.Part.Price)),
                    priceWithDiscount = String.Format("{0:F2}",
                        s.Car.PartsCars.Sum(pc => pc.Part.Price) * (100 - s.Discount) / 100)
                })
                .ToArray();


        return JsonConvert.SerializeObject(
               salesDiscount,
               Formatting.Indented);
               //new JsonSerializerSettings()
               //{
               //    ContractResolver = contractResolver,
               //    NullValueHandling = NullValueHandling.Ignore,
               //});
    }

        private static IMapper CreateMapper()
    {
        return new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));
    }

    private static IContractResolver ConfigureCamelCaseNaming()
    {
        return new DefaultContractResolver()
        {
            NamingStrategy = new CamelCaseNamingStrategy(false, true)
        };
    }
}