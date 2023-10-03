
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUniBazar.Data.Models
{

    public class Ad
    {
        public Ad()
        {
            this.AdsBuyers = new HashSet<AdBuyer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(250)]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; } = null!;
        public IdentityUser Owner { get; set; } = null!;

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ICollection<AdBuyer> AdsBuyers { get; set; }

    }
}
