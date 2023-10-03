using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Boardgames.DataProcessor.ImportDto;

public class JSONImportSellerDto
{
    [JsonProperty("Name")]
    [Required]
    [MinLength(5)]
    [MaxLength(20)]
    public string Name { get; set; }

    [JsonProperty("Address")]
    [Required]
    [MinLength(5)]
    [MaxLength(30)]
    public string Address { get; set; }

    [JsonProperty("Country")]
    [Required]
    public string Country { get; set; }

    [JsonProperty("Website")]
    [Required]
    [RegularExpression(@"^www\.[A-Za-z0-9-]+\.com$")]
    public string Website { get; set; }

    [JsonProperty("Boardgames")]
    public int[] Boardgames { get; set; }
}
