using BookShop.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Models;

public class Category
{
    public Category()
    {
        this.CategoryBooks = new HashSet<BookCategory>();
    }

    [Key]
    public int CategoryId { get; set; }

    [MaxLength(ValidationConstraints.CategoryNameMaxLength)]
    public string Name { get; set; } = null!;

    public virtual ICollection<BookCategory> CategoryBooks { get; set; }

}
