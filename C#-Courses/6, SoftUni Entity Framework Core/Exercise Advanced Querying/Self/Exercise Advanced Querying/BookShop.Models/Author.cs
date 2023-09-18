namespace BookShop.Models;

using System.ComponentModel.DataAnnotations;

using BookShop.Data.Common;

public class Author
{
    public Author()
    {
        this.Books= new HashSet<Book>();
    }

    [Key]
    public int AuthorId { get; set; }

    
    [MaxLength(ValidationConstraints.AuthorFirstNameMaxLength)]
    public string? FirstName { get; set; }

    [Required]
    [MaxLength(ValidationConstraints.AuthorLastNameMaxLength)]
    public string LastName { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; }
}