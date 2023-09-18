using System.ComponentModel.DataAnnotations;

namespace SoftUniBazar.Models
{
    public class AddAdViewModel
    {
        public AddAdViewModel()
        {
            this.Categories = new HashSet<CategoryViewModel>();
        }

        [Required]
        [StringLength(25,MinimumLength =5)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(250, MinimumLength = 15)]
        public string Description { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Range(1, 5)]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
