using BookShop.Data.Common;
using BookShop.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models;

public class Book
{
    public Book()
    {
        this.BookCategories = new HashSet<BookCategory>();
    }

    [Key]
    public int BookId { get; set; }

    [MaxLength(ValidationConstraints.BookTitleMaxLength)]
    public string Title { get; set; } = null!;

    [MaxLength(ValidationConstraints.BookDescriptionMaxLength)]
    public string Description { get; set; }=null!;

    public DateTime? ReleaseDate { get; set; }

    public int Copies { get; set; }

    public decimal Price { get; set; }

    public EditionType EditionType { get; set; }

    public AgeRestriction AgeRestriction { get; set; }

    [ForeignKey(nameof(Author))]
    public int AuthorId { get; set; }
    public virtual Author Author { get; set; }


    public virtual ICollection<BookCategory> BookCategories { get; set; }
}
