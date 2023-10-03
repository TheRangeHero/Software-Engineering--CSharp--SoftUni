namespace ProductShop;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;


using Data;
using Models;
using DTOs.Import;
using DTOs.Export;

public class StartUp
{
    public static void Main()
    {
        ProductShopContext context = new ProductShopContext();

        // string inputJson = File.ReadAllText(@"../../../Datasets/categories-products.json");

        string result = GetUsersWithProducts(context);

        Console.WriteLine(result);
    }

    public static string ImportUsers(ProductShopContext context, string inputJson)
    {
        IMapper mapper = CreateMapper();


        ImportUserDTO[] userDtos =
            JsonConvert.DeserializeObject<ImportUserDTO[]>(inputJson);
        //User[] users = mapper.Map<User[]>(userDtos)
        ICollection<User> validUsers = new HashSet<User>();
        foreach (ImportUserDTO userDTO in userDtos)
        {
            User user = mapper.Map<User>(userDTO);

            validUsers.Add(user);
        }

        context.AddRange(validUsers);
        context.SaveChanges();

        return $"Successfully imported {validUsers.Count}";
    }
    public static string ImportProducts(ProductShopContext context, string inputJson)
    {
        IMapper mapper = CreateMapper();

        ImportProductDTO[] productDtops =
            JsonConvert.DeserializeObject<ImportProductDTO[]>(inputJson);

        Product[] products = mapper.Map<Product[]>(productDtops);

        context.Products.AddRange(products);
        context.SaveChanges();

        return $"Successfully imported {products.Length}";
    }
    public static string ImportCategories(ProductShopContext context, string inputJson)
    {
        IMapper mapper = CreateMapper();

        ImportCategoryDto[] categoriesDtos =
            JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);

        ICollection<Category> validCategories = new HashSet<Category>();
        foreach (ImportCategoryDto item in categoriesDtos)
        {
            if (String.IsNullOrEmpty(item.Name))
            {
                continue;
            }

            Category category = mapper.Map<Category>(item);
            validCategories.Add(category);
        }

        context.Categories.AddRange(validCategories);
        context.SaveChanges();

        return $"Successfully imported {validCategories.Count}";
    }
    public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
    {
        IMapper mapper = CreateMapper();

        ImportCategoryProductDTO[] categoryProductDTOs =
            JsonConvert.DeserializeObject<ImportCategoryProductDTO[]>(inputJson);

        ICollection<CategoryProduct> validEntries = new HashSet<CategoryProduct>();
        foreach (var item in categoryProductDTOs)
        {
            //if (!context.Categories.Any(c=>c.Id == item.CategoryId) || 
            //    !context.Products.Any(p=>p.Id == item.ProductId))
            //{
            //    continue;
            //}

            CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(item);
            validEntries.Add(categoryProduct);
        }

        context.CategoriesProducts.AddRange(validEntries);
        context.SaveChanges();

        return $"Successfully imported {validEntries.Count}";
    }
    public static string GetProductsInRange(ProductShopContext context)
    {

        // Anonymous object + Mannual Mapping 
        //var products = context.Products
        //    .Where(p=>p.Price>=500 && p.Price <=1000)
        //    .OrderBy(p=>p.Price)
        //    .Select(p=> new
        //    {
        //    name = p.Name,
        //    price = p.Price,
        //    seller = p.Seller.FirstName + " " + p.Seller.LastName,
        //    })
        //    .AsNoTracking()
        //    .ToArray();



        //Automapper
        IMapper mapper = CreateMapper();

        ExportProductsInRangeDTO[] productDtos = context.Products
            .Where(p => p.Price >= 500 && p.Price <= 1000)
            .OrderBy(p => p.Price)
            .AsNoTracking()
            .ProjectTo<ExportProductsInRangeDTO>(mapper.ConfigurationProvider)
            .ToArray();

        return JsonConvert.SerializeObject(productDtos, Formatting.Indented);
    }
    public static string GetSoldProducts(ProductShopContext context)
    {
        IContractResolver contractResolver = ConfigureCamelCaseNaming();



        var users = context.Users
            .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.FirstName)
            .Select(u => new
            {
                u.FirstName,
                u.LastName,
                SoldProducts = u.ProductsSold
                .Where(p => p.Buyer != null)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    BuyerFirstName = p.Buyer.FirstName,
                    BuyerLastName = p.Buyer.LastName,
                })
                .ToArray()
            })
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(users,
           Formatting.Indented,
           new JsonSerializerSettings()
           {
               ContractResolver = contractResolver
           });
    }
    public static string GetCategoriesByProductsCount(ProductShopContext context)
    {
        IContractResolver contractResolver = ConfigureCamelCaseNaming();

        var categories = context.Categories
            .OrderByDescending(c => c.CategoriesProducts.Count)
            .Select(c => new
            {
                Category = c.Name,
                ProductsCount = c.CategoriesProducts.Count,
                AveragePrice = (c.CategoriesProducts.Any() ?
                c.CategoriesProducts.Average(cp => cp.Product.Price) : 0).ToString("f2"),
                TotalRevenue = (c.CategoriesProducts.Any() ?
                c.CategoriesProducts.Sum(cp => cp.Product.Price) : 0).ToString("f2")
            })
            .AsNoTracking().
            ToArray();

        return JsonConvert.SerializeObject(categories,
            Formatting.Indented,
            new JsonSerializerSettings()
            {
                ContractResolver = contractResolver
            });
    }
    public static string GetUsersWithProducts(ProductShopContext context)
    {
        IContractResolver contractResolver = ConfigureCamelCaseNaming();

        var users = context.Users
            .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
        .Select(u => new
        { //UserDTO
            u.FirstName,
            u.LastName,
            u.Age,
            SoldProducts = new
            { // ProductWrapperDTO
                Count = u.ProductsSold.Count(p => p.Buyer != null),
                Products = u.ProductsSold.Where(p => p.Buyer != null)
                .Select(p => new
                { //ProductDTO
                    p.Name,
                    p.Price
                })
                .ToArray()
            }
        })
        .OrderByDescending(u => u.SoldProducts.Count)
        .AsNoTracking()
        .ToArray();

        var userWrapperDto = new
        {
            UsersCount = users.Length,
            Users = users
        };

        return JsonConvert.SerializeObject(userWrapperDto,
            Formatting.Indented,
            new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                NullValueHandling = NullValueHandling.Ignore
            });
    }



    private static IContractResolver ConfigureCamelCaseNaming()
    {
        return new DefaultContractResolver()
        {
            NamingStrategy = new CamelCaseNamingStrategy(false, true)
        };
    }
    private static IMapper CreateMapper()
    {
        return new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductShopProfile>();
        }));

    }
}