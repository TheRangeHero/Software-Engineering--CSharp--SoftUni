namespace ProductShop;

using AutoMapper;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

public class ProductShopProfile : Profile
{
    public ProductShopProfile() 
    {

        this.CreateMap<ImportUserDTO, User>();

        //Procut
        this.CreateMap<ImportProductDTO, Product>();
        this.CreateMap<Product, ExportProductsInRangeDTO>()
            .ForMember(d => d.ProductName,
                opt => opt.MapFrom(s => s.Name))
            .ForMember(d => d.ProductPrice,
                opt => opt.MapFrom(s => s.Price))
            .ForMember(d => d.SellerName,
                opt => opt.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));

        this.CreateMap<ImportCategoryDto, Category>();

        this.CreateMap<ImportCategoryProductDTO, CategoryProduct>();

    }
}
