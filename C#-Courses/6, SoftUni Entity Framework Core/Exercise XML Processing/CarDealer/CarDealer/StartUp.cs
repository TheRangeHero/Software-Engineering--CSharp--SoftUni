using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();
            //string inputXml = File.ReadAllText("../../../Datasets/sales.xml");

            string result = GetCarsWithTheirListOfParts(context);
            Console.WriteLine(result);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            //XmlRootAttribute xmlRoot = new XmlRootAttribute("Suppliers");
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]), xmlRoot);

            //StringReader reader = new StringReader(inputXml);
            //ImportSupplierDto[] importSupplierDtos = (ImportSupplierDto[])xmlSerializer.Deserialize(reader);

            IMapper mapper = CreateMapper();

            XmlHelper xmlHelper = new XmlHelper();
            ImportSupplierDto[] supplierDtos = xmlHelper.Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers");

            ICollection<Supplier> validSuppliers = new HashSet<Supplier>();
            foreach (var item in supplierDtos)
            {
                if (string.IsNullOrEmpty(item.Name))
                {
                    continue;
                }

                //Manual mapping without Automapper
                //Supplier supplier = new Supplier()
                //{
                //    Name = item.Name,
                //    IsImporter = item.isImporter
                //};


                //AutoMapper
                Supplier supplier = mapper.Map<Supplier>(item);
                validSuppliers.Add(supplier);
            }
            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count()}";

        }
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();

            XmlHelper xmlHelper = new XmlHelper();

            ImportPartDto[] importPartDtos = xmlHelper.Deserialize<ImportPartDto[]>(inputXml, "Parts");

            ICollection<Part> validparts = new HashSet<Part>();
            foreach (var item in importPartDtos)
            {
                if (string.IsNullOrEmpty(item.Name))
                {
                    continue;
                }
                if (!item.SupplierId.HasValue ||
                    !context.Suppliers.Any(s => s.Id == item.SupplierId))
                {
                    //Missing or wrong supplier ID
                    continue;
                }

                Part part = mapper.Map<Part>(item);
                validparts.Add(part);
            }

            context.Parts.AddRange(validparts);
            context.SaveChanges();

            return $"Successfully imported {validparts.Count}";
        }
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCarDto[] importCarDtos = xmlHelper.Deserialize<ImportCarDto[]>(inputXml, "Cars");

            ICollection<Car> validCars = new HashSet<Car>();
            foreach (var item in importCarDtos)
            {
                if (string.IsNullOrEmpty(item.Make) ||
                    string.IsNullOrEmpty(item.Model))
                {
                    continue;
                }

                Car car = mapper.Map<Car>(item);

                foreach (var partDto in item.Parts.DistinctBy(p => p.PartId))
                {
                    if (!context.Parts.Any(p => p.Id == partDto.PartId))
                    {
                        continue;
                    }

                    PartCar partCar = new PartCar()
                    {
                        PartId = partDto.PartId
                    };
                    car.PartsCars.Add(partCar);
                }

                validCars.Add(car);

            }
            context.Cars.AddRange(validCars);
            context.SaveChanges();

            return $"Successfully imported {validCars.Count}";
        }
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCustomerDto[] customerDtos = xmlHelper.Deserialize<ImportCustomerDto[]>(inputXml, "Customers");

            ICollection<Customer> validCustomers = new HashSet<Customer>();
            foreach (var customerDto in customerDtos)
            {
                if (string.IsNullOrEmpty(customerDto.Name) ||
                    string.IsNullOrEmpty(customerDto.BirthDate))
                {
                    continue;
                }

                Customer customer = mapper.Map<Customer>(customerDto);
                validCustomers.Add(customer);
            }

            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            return $"Successfully imported {validCustomers.Count}";
        }
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportSaleDto[] saleDtos = xmlHelper.Deserialize<ImportSaleDto[]>(inputXml, "Sales");

            //Optimization
            ICollection<int> dbCarIds = context.Cars.Select(c => c.Id).ToArray();


            ICollection<Sale> validSales = new HashSet<Sale>();
            foreach (var saleDto in saleDtos)
            {
                if (!saleDto.CarId.HasValue ||
                    !dbCarIds.Any(id => id == saleDto.CarId.Value))
                {
                    continue;
                }

                Sale sale = mapper.Map<Sale>(saleDto);
                validSales.Add(sale);
            }

            context.Sales.AddRange(validSales);
            context.SaveChanges();

            return $"Successfully imported {validSales.Count}";
        }



        public static string GetCarsWithDistance(CarDealerContext context)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ExportCarDto[] cars = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<ExportCarDto>(mapper.ConfigurationProvider)
                .ToArray();

            //Inside XmlHelper
            //XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarDto[]), xmlRoot);

            //XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            //namespaces.Add(string.Empty, string.Empty);

            //using StringWriter writer = new StringWriter(stringBuilder);
            //xmlSerializer.Serialize(writer, cars, namespaces);

            return xmlHelper.Serialize<ExportCarDto[]>(cars, "cars");
        }
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ExportCarFromBMWDto[] carDtos = context.Cars
                .Where(c=>c.Make.ToUpper() == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ProjectTo<ExportCarFromBMWDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize(carDtos, "cars");
        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ExportSuppliersDto[] exportSuppliersDtos = context.Suppliers
                .Where(s=>s.IsImporter==false)
                .ProjectTo<ExportSuppliersDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize<ExportSuppliersDto[]>(exportSuppliersDtos, "suppliers");
        }        
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ExportCarWithPartsDto[] carsWithParts = context
                .Cars
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ProjectTo<ExportCarWithPartsDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize(carsWithParts, "cars");
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            //IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            //ExportCustomerDto[] exportCustomers = context.Customers
            //    .Where(c=>c.Sales.Count>0)
            //    .ProjectTo<ExportCustomerDto>(mapper.ConfigurationProvider)
            //    .OrderByDescending(c=>c.SpentMoney)
            //    .ToArray();

            //return xmlHelper.Serialize(exportCustomers, "customers");

            var totalSales = context.Customers.Where(c => c.Sales.Count() > 0)
                                   .Select(c => new
                                   {
                                       fullName = c.Name,
                                       boughtCars = c.Sales.Count(),
                                       IsYoungDriver = c.IsYoungDriver,
                                       spentMoney = c.Sales.ToArray()
                                   })
                                   .ToList();

            var orderedTotalSales = totalSales.Select(c => new ExportCustomerDto(
                c.fullName,
                c.boughtCars.ToString(),
                c.spentMoney.Sum(sm => sm.Car.PartsCars.Sum(p => p.Part.Price)) * (c.IsYoungDriver ? .95M : 1.0M)))
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            var formatedTotalSales = orderedTotalSales.Select(c => new ExportCustomerDto(
                c.Name,
                c.BoughtCars,
                (decimal)(int)(c.SpentMoney * 100) / 100M)).ToArray();

            return xmlHelper.Serialize<ExportCustomerDto[]>(formatedTotalSales, "customers");

        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var sales = context.Sales
                .ProjectTo<ExportSalesDiscount>(mapper.ConfigurationProvider)
                .ToList();

            return xmlHelper.Serialize(sales, "sales");
        }

        private static IMapper CreateMapper()
        => new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));
    }
}