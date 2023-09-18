namespace BookShop;

using BookShop.Models.Enums;
using Data;
using Initializer;
using Microsoft.VisualBasic;
using System.Globalization;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        using var dbContext = new BookShopContext();
        //DbInitializer.ResetDatabase(dbContext);

        //int input = int.Parse(Console.ReadLine());

        //string result = GetMostRecentBooks(dbContext);

        // Console.WriteLine(result);

        Console.WriteLine( RemoveBooks(dbContext));
    }

    public static string GetBooksByAgeRestriction(BookShopContext context, string command)
    {


        try
        {
            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var bookTitles = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }
        catch (Exception e)
        {

            return null;
        }

        //bool hasPasered = Enum.TryParse(typeof(AgeRestriction), command, true, out object? ageRestrictionObj);
        //AgeRestriction ageRestriction;
        //if (hasPasered)
        //{
        //    ageRestriction = (AgeRestriction)ageRestrictionObj;

        //    var bookTitles = context.Books
        //        .Where(b=>b.AgeRestriction == ageRestriction)
        //        .OrderBy(b=>b.Title)
        //        .Select(b=>b.Title)
        //        .ToArray();

        //    return string.Join(Environment.NewLine, bookTitles);
        //}

        //return null;
    }
    public static string GetGoldenBooks(BookShopContext context)
    {
        string[] bookTitles = context.Books
            .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToArray();

        return string.Join(Environment.NewLine, bookTitles);
    }
    public static string GetBooksByPrice(BookShopContext context)
    {
        StringBuilder sb = new StringBuilder();

        var bookTitles = context.Books
            .Where(b => b.Price > 40)
            .OrderByDescending(b => b.Price)
            .Select(b => new
            {
                Title = b.Title,
                Price = b.Price.ToString("f2")
            })
            .ToArray();

        foreach (var book in bookTitles)
        {
            sb
                .AppendLine($"{book.Title} - ${book.Price}");
        }

        return sb.ToString().TrimEnd();
    }
    public static string GetBooksNotReleasedIn(BookShopContext context, int year)
    {
        var bookTitles = context.Books
            .Where(b => b.ReleaseDate.Value.Year != year && b.ReleaseDate != null)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToArray();

        return string.Join(Environment.NewLine, bookTitles);
    }
    public static string GetBooksByCategory(BookShopContext context, string input)
    {
        string[] categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(c => c.ToLower())
            .ToArray();

        string[] bookTitles = context.Books
            .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
            .OrderBy(b => b.Title)
            .Select(b => b.Title)
            .ToArray();

        return string.Join(Environment.NewLine, bookTitles);
    }
    public static string GetBooksReleasedBefore(BookShopContext context, string date)
    {
        StringBuilder sb = new StringBuilder();

        try
        {
            DateTime givenDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var booksBeforeDate = context.Books
                .Where(b => b.ReleaseDate < givenDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    Title = b.Title,
                    EditionType = b.EditionType,
                    Price = b.Price.ToString("f2")
                })
                .ToArray();

            foreach (var b in booksBeforeDate)
            {
                sb
                    .AppendLine($"{b.Title} - {b.EditionType} - ${b.Price}");
            }

            return sb.ToString().TrimEnd();
        }
        catch (Exception e)
        {

            throw null;
        }

    }
    public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
    {
        var authors = context.Authors
            .Where(a => a.FirstName.EndsWith(input))
            .OrderBy(a => a.FirstName)
            .ThenBy(a => a.LastName)
            .Select(a => $"{a.FirstName} {a.LastName}")
            .ToArray();

        return string.Join(Environment.NewLine, authors);
    }
    public static string GetBookTitlesContaining(BookShopContext context, string input)
    {
        var bookTitles = context.Books
            .Where(b => b.Title.ToLower().Contains(input.ToLower())).
            OrderBy(b => b.Title)
            .Select(b => b.Title)
            .ToArray();

        return string.Join(Environment.NewLine, bookTitles);
    }
    public static string GetBooksByAuthor(BookShopContext context, string input)
    {
        StringBuilder sb = new StringBuilder();

        var bookTitles = context.Books
            .Where(a => a.Author.LastName.ToLower().StartsWith(input.ToLower()))
            .OrderBy(b => b.BookId)
            .Select(b => new
            {
                Title = b.Title,
                Author = b.Author.FirstName == null ? " " : b.Author.FirstName + " " + b.Author.LastName,
            })
            .ToArray();

        foreach (var b in bookTitles)
        {
            sb
                .AppendLine($"{b.Title} ({b.Author})");
        }

        return sb.ToString().TrimEnd();
    }
    public static int CountBooks(BookShopContext context, int lengthCheck)
    {
        var books = context.Books
            .Where(b => b.Title.Length > lengthCheck)
            .Count();

        return books;
    }
    public static string CountCopiesByAuthor(BookShopContext context)
    {
        StringBuilder sb = new StringBuilder();

        var authorsWithBookCopies = context.Authors
            .Select(a => new
            {
                FullName = a.FirstName + " " + a.LastName,
                TotalCopies = a.Books.Sum(b => b.Copies)
            })
            .ToArray()
           .OrderByDescending(b => b.TotalCopies);

        foreach (var a in authorsWithBookCopies)
        {
            sb
                .AppendLine($"{a.FullName} - {a.TotalCopies}");
        }

        return sb.ToString().TrimEnd();
    }
    public static string GetTotalProfitByCategory(BookShopContext context)
    {
        StringBuilder sb = new StringBuilder();

        var categories = context.Categories
            .Select(c => new
            {
                CategoryName = c.Name,
                TotalProfit = c.CategoryBooks
                .Sum(cb => cb.Book.Copies * cb.Book.Price)
            })
            .ToArray()
            .OrderByDescending(c => c.TotalProfit)
            .ThenBy(c => c.CategoryName);

        foreach (var c in categories)
        {
            sb.AppendLine($"{c.CategoryName} ${c.TotalProfit:f2}");
        }

        return sb.ToString().TrimEnd();
    }
    public static string GetMostRecentBooks(BookShopContext context)
    {
        StringBuilder sb = new StringBuilder();

        var books = context.Categories
            .OrderBy(c => c.Name)
            .Select(c => new
            {
                CategpryName = c.Name,
                MostRecentBooks = c.CategoryBooks
                    .OrderByDescending(cb => cb.Book.ReleaseDate)
                    .Take(3)
                    .Select(cb => new
                    {
                        BookName = cb.Book.Title,
                        ReleaseYear = cb.Book.ReleaseDate.Value.Year
                    })
                    .ToArray()
            }).ToArray();

        foreach (var c in books)
        {
            sb.AppendLine($"--{c.CategpryName}");
            foreach (var b in c.MostRecentBooks)
            {
                sb.AppendLine($"{b.BookName} ({b.ReleaseYear})");
            }
        }

        return sb.ToString().TrimEnd();
    }
    public static void IncreasePrices(BookShopContext context)
    {
        var books = context.Books
            .Where(b => b.ReleaseDate.HasValue &&
                        b.ReleaseDate.Value.Year < 2010)
            .ToArray();

        foreach (var b in books)
        {
            b.Price += 5;
        }

        //context.SaveChanges(); => without bulk
        context.BulkUpdate(books);
    }
    public static int RemoveBooks(BookShopContext context)
    {
        var booksToDelete = context.Books
            .Where(b => b.Copies < 4200)
            .ToArray();

        int removedBooks = booksToDelete.Count();

        context.BulkDelete(booksToDelete);

        return removedBooks;
    }

}


