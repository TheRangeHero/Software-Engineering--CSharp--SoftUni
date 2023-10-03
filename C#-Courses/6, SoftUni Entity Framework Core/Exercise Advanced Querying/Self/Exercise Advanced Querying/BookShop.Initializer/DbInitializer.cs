namespace BookShop.Initializer;

using Data;

public class DbInitializer
{
    public static void ResetDatabase(BookShopContext context)
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        Console.WriteLine("BookShop database created successfully.");
    }
}