namespace BookShop;

using Data;
using Initializer;

internal class StartUp
{
    static void Main(string[] args)
    {
        using var db = new BookShopContext();
        DbInitializer.ResetDatabase(db);
    }
}