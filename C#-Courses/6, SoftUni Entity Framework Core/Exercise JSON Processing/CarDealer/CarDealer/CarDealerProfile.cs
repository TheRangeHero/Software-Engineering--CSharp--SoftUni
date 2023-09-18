using AutoMapper;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Globalization;
using System.Net;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierDTO, Supplier>();

            this.CreateMap<ImportPartDTO, Part>();

            //this.CreateMap<ImportCarDTO, Car>()
            //    .ForMember(dest => dest.Make, opt => opt.MapFrom(src => src.Make))
            //    .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
            //    .ForMember(dest => dest.TraveledDistance, opt => opt.MapFrom(src => src.TraveledDistance))

            this.CreateMap<ImportCustomerDTO, Customer>()
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => DateTime.ParseExact(src.BirthDate, "yyyy-MM-dd'T'HH:mm:ss", CultureInfo.InvariantCulture)))
               .ForMember(dest => dest.IsYoungDriver, opt => opt.MapFrom(src => src.IsYoungDriver));


            this.CreateMap<ImportSalesDTO, Sale>();
        }
    }
}
