namespace CarDealer;

using AutoMapper;
using CarDealer.DTOs.Export;
using DTOs.Import;
using Models;
using System.Globalization;

public class CarDealerProfile : Profile
{
    public CarDealerProfile()
    {
        //Supplier
        this.CreateMap<ImportSupplierDto, Supplier>();
        this.CreateMap<Supplier, ExportSuppliersDto>()
            .ForMember(d => d.PartsCount, opt => opt.MapFrom(s => s.Parts.Count));


        //Part
        this.CreateMap<ImportPartDto, Part>()
            .ForMember(d => d.SupplierId, opt => opt.MapFrom(s => s.SupplierId.Value));

        this.CreateMap<Part, ExportCarPartDto>();


        //Car
        this.CreateMap<ImportCarDto, Car>()
            .ForSourceMember(s => s.Parts, opt => opt.DoNotValidate());

        this.CreateMap<Car, ExportCarDto>();
        this.CreateMap<Car, ExportCarFromBMWDto>();
        this.CreateMap<Car, ExportCarWithPartsDto>()
            .ForMember(d => d.Parts,
            opt => opt.MapFrom(s => s.PartsCars
            .Select(pc => pc.Part)
            .OrderByDescending(p => p.Price)
            .ToArray()));

        //Customer

        this.CreateMap<ImportCustomerDto, Customer>()
            .ForMember(d => d.BirthDate, opt => opt.MapFrom(s => DateTime.Parse(s.BirthDate, CultureInfo.InvariantCulture)));

        this.CreateMap<Customer, ExportCustomerDto>()
            .ForMember(d => d.BoughtCars, opt => opt.MapFrom(s => s.Sales.Count()))
              .ForMember(d => d.SpentMoney, obj => obj.MapFrom(s => Math.Truncate(100 * (s.Sales.SelectMany(sa =>
                 sa.Car.PartsCars.Select(pc => pc.Part.Price * (s.IsYoungDriver ? 0.95m : 1))).Sum())) / 100));


        //Sale

        this.CreateMap<ImportSaleDto, Sale>()
            .ForMember(d => d.CarId, opt => opt.MapFrom(s => s.CarId.Value));


       // CreateMap<Car, ExportCarAtributeDto>();
        CreateMap<Sale, ExportSalesDiscount>()
                .ForMember(dest => dest.CarDto, opt => opt.MapFrom(src => new ExportCarAtributeDto
                {
                    Make = src.Car.Make,
                    Model = src.Car.Model,
                    TraveledDistance = src.Car.TraveledDistance
                }))
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src =>Convert.ToInt32 (src.Discount)))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Car.PartsCars.Sum(pc => pc.Part.Price)))
                .ForMember(dest => dest.PriceWithDiscount,
                    opt => opt.MapFrom(src =>
                        (src.Car.PartsCars.Sum(pc => pc.Part.Price) - ((src.Car.PartsCars.Sum(pc => pc.Part.Price) * (src.Discount / 100))))));


    }
}
