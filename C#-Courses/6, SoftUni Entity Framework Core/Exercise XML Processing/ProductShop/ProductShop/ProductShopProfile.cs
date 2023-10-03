namespace ProductShop; 

using AutoMapper;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

public class ProductShopProfile : Profile
{
    public ProductShopProfile()
    {
        //User
        this.CreateMap<ImportUsersDto, User>();
        this.CreateMap<Product, ExportSoldProductforUserDto>();
        this.CreateMap<User, ExportUserWithSoldProductsDto>()
            .ForMember(dest => dest.SoldProducts, opt => opt.MapFrom(s => s.ProductsSold.Select(u => new ExportSoldProductforUserDto
             {
                 Name = u.Name,
                 Price = u.Price,
             })));
        this.CreateMap<ImportProductDto, Product>();

        this.CreateMap<Product, ExportProductsInRangeDto>()
            .ForMember(dest => dest.BuyerName, opt => opt.MapFrom(src=>$"{src.Buyer!.FirstName} {src.Buyer.LastName}"));

        //Category
        this.CreateMap<ImportCategoryDto, Category>();
        this.CreateMap<Category, Export07CategoryByProductDto>()
            .ForMember(dest => dest.ProductCount, opt => opt.MapFrom(s => s.CategoryProducts.Count()))
            .ForMember(dest => dest.AveragePrice, opt => opt.MapFrom(s => s.CategoryProducts.Average(a => a.Product.Price)))
            .ForMember(dest => dest.TotalRevenue, opt => opt.MapFrom(s => s.CategoryProducts.Sum(a => a.Product.Price)));

        //CategoryProduct
        this.CreateMap<ImportCategoryProductDto, CategoryProduct>();


        this.CreateMap<Product, ExportDTO08ProductSoldForUser>();
        this.CreateMap<User, ExportDTO08ProdictsForUser>()
            .ForMember(dst => dst.Count,
                opt => opt.MapFrom(src => src.ProductsSold.Count));
        this.CreateMap<User, ExportDTO08UserWithSoldProducts>()
            .ForMember(dst => dst.Age,
                opt => opt.MapFrom(src => src.Age!.Value))
            .ForMember(dst => dst.PRODUCTS,
                opt => opt.MapFrom(src => src));

    }
}
