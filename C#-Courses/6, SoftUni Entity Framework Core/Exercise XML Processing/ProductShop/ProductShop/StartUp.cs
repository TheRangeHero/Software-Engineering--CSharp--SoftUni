namespace ProductShop;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

using Data;
using DTOs.Export;
using DTOs.Import;
using Models;
using Utilities;


public class StartUp
{
    public static void Main()
    {
        ProductShopContext context = new ProductShopContext();

        //string inputXml = File.ReadAllText(@"../../../Datasets/categories-products.xml");

        string result = GetUsersWithProducts(context);
        Console.WriteLine(result);
    }

    public static string ImportUsers(ProductShopContext context, string inputXml)
    {
        IMapper mapper = CreateMapper();
        XmlHelper xmlHelper = new XmlHelper();

        ImportUsersDto[] importUsersDtos = xmlHelper.Deserialize<ImportUsersDto[]>(inputXml, "Users");

        ICollection<User> validUsers = new HashSet<User>();

        foreach (ImportUsersDto userDto in importUsersDtos)
        {
            User user = mapper.Map<User>(userDto);
            validUsers.Add(user);
        }

        context.Users.AddRange(validUsers);
        context.SaveChanges();

        return $"Successfully imported {validUsers.Count}";

    }
    public static string ImportProducts(ProductShopContext context, string inputXml)
    {
        IMapper mapper = CreateMapper();
        XmlHelper xmlHelper = new XmlHelper();

        ImportProductDto[] importProductDtos = xmlHelper.Deserialize<ImportProductDto[]>(inputXml, "Products");
        Product[] products = mapper.Map<Product[]>(importProductDtos);

        //ICollection <Product> products = new HashSet<Product>();
        //foreach (var productDto in importProductDtos)
        //{
        //    if (!productDto.BuyerId.HasValue )
        //    {
        //        continue;
        //    }
        //    Product product = mapper.Map<Product>(productDto);
        //    products.Add(product);
        //}

        context.Products.AddRange(products);
        context.SaveChanges();

        return $"Successfully imported {products.Length}";
    }
    public static string ImportCategories(ProductShopContext context, string inputXml)
    {
        IMapper mapper = CreateMapper();
        XmlHelper xmlHelper = new XmlHelper();

        ImportCategoryDto[] importCategoryDtos = xmlHelper.Deserialize<ImportCategoryDto[]>(inputXml, "Categories");
        ICollection<Category> validCategories = new HashSet<Category>();
        foreach (var categoryDto in importCategoryDtos)
        {
            if (string.IsNullOrEmpty(categoryDto.Name))
            {
                continue;
            }

            Category category = mapper.Map<Category>(categoryDto);
            validCategories.Add(category);
        }


        context.Categories.AddRange(validCategories);
        context.SaveChanges();

        return $"Successfully imported {validCategories.Count}";
    }
    public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
    {
        IMapper mapper = CreateMapper();
        XmlHelper xmlHelper = new XmlHelper();

        ImportCategoryProductDto[] importCategoryProductDtos = xmlHelper.Deserialize<ImportCategoryProductDto[]>(inputXml, "CategoryProducts");
        CategoryProduct[] categoryProducts = mapper.Map<CategoryProduct[]>(importCategoryProductDtos);
        //ICollection<CategoryProduct> validCategoryProducts = new HashSet<CategoryProduct>();
        //foreach (var categoryProductDto in importCategoryProductDtos)
        //{
        //    if (!context.Products.Any(p => p.Id == categoryProductDto.ProductId ||
        //        !context.Categories.Any(c => c.Id == categoryProductDto.CategoryId)))
        //    {
        //        continue;
        //    }

        //    CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(categoryProductDto);
        //    validCategoryProducts.Add(categoryProduct);
        //}

        context.CategoryProducts.AddRange(categoryProducts);
        context.SaveChanges();

        return $"Successfully imported {categoryProducts.Length}";

    }

    public static string GetProductsInRange(ProductShopContext context)
    {
        IMapper mapper = CreateMapper();
        XmlHelper xmlHelper = new XmlHelper();

        ExportProductsInRangeDto[] exportProductsInRangeDtos = context.Products
            .Where(p => p.Price >= 500 && p.Price <= 1000)
            .OrderBy(p => p.Price)
            .Take(10)
            .AsNoTracking()
            .ProjectTo<ExportProductsInRangeDto>(mapper.ConfigurationProvider)
            .ToArray();

        return xmlHelper.Serialize<ExportProductsInRangeDto[]>(exportProductsInRangeDtos, "Products");
    }
    public static string GetSoldProducts(ProductShopContext context)
    {
        IMapper mapper = CreateMapper();
        XmlHelper xmlHelper = new XmlHelper();

        ExportUserWithSoldProductsDto[] exportUserWithSoldProductsDtos = context.Users
            .Where(u=>u.ProductsSold.Count() >= 1)
            .OrderBy(u=>u.LastName)
            .ThenBy(u=>u.FirstName)
            .Take(5)
            .ProjectTo<ExportUserWithSoldProductsDto>(mapper.ConfigurationProvider)
            .AsNoTracking()
            .ToArray();

        return xmlHelper.Serialize<ExportUserWithSoldProductsDto>(exportUserWithSoldProductsDtos, "Users");

    }
    public static string GetCategoriesByProductsCount(ProductShopContext context)
    {
        IMapper mapper = CreateMapper();
        XmlHelper xmlHelper = new XmlHelper();

        //Export07CategoryByProductDto[] export07CategoryByProductDtos = context.Categories
        //    .ProjectTo<Export07CategoryByProductDto>(mapper.ConfigurationProvider)
        //    .OrderByDescending(n=>n.ProductCount)
        //    .ThenBy(n=>n.TotalRevenue)
        //    .AsNoTracking()
        //    .ToArray();



        Export07CategoryByProductDto[] categoryByProductDtos = context.Categories
            .Select(s => new Export07CategoryByProductDto
            {
                CategoryName = s.Name,
                ProductCount = s.CategoryProducts.Count(),
                AveragePrice = s.CategoryProducts.Average(p => p.Product.Price),
                TotalRevenue = s.CategoryProducts.Sum(p => p.Product.Price),
            })
            .OrderByDescending(u => u.ProductCount)
            .ThenBy(u => u.TotalRevenue)
            //.ProjectTo<Export07CategoryByProductDto>(mapper.ConfigurationProvider)
            .AsNoTracking()
            .ToArray();

        return xmlHelper.Serialize<Export07CategoryByProductDto[]>(categoryByProductDtos, "Categories");

    }
    public static string GetUsersWithProducts(ProductShopContext context)
    {
        IMapper mapper = CreateMapper();

        XmlHelper xmlHelper = new XmlHelper();

        List<ExportDTO08UserWithSoldProducts> exportDTOs = context.Users
              .Where(u => u.ProductsSold.Count > 0)
              .OrderByDescending(u => u.ProductsSold.Count)
              .Take(10)
              .ProjectTo<ExportDTO08UserWithSoldProducts>(mapper.ConfigurationProvider)
              .ToList();

        foreach (var exportDTO in exportDTOs)
        {
            exportDTO.PRODUCTS.ProductsSold = exportDTO.PRODUCTS.ProductsSold.OrderByDescending(ps => ps.Price).ToList();
        }

        ExportDTO08UserData userData = new ExportDTO08UserData()
        {
            Count = context.Users.Count(u => u.ProductsSold.Count > 0),
            USERS = exportDTOs
        };

        return xmlHelper.Serialize<ExportDTO08UserData>(userData, "Users");
    }


private static IMapper CreateMapper()
        => new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductShopProfile>();
        }));
}
