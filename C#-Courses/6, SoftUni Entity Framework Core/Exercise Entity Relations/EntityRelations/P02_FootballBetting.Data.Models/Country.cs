namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class Country
{
    public Country()
    {
        this.Towns = new HashSet<Town>();
    }


    [Key]
    public int CountryId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.ColorNameMaxLength)]
    public string Name { get; set; } = null!;



    //TODO: Create navigation collection
    public virtual ICollection<Town> Towns { get;}
}
