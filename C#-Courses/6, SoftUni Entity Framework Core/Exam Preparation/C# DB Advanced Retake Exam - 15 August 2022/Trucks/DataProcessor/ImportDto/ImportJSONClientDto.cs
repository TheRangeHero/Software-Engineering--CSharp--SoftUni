namespace Trucks.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

public class ImportJSONClientDto
{

    [Required]
    [MinLength(3)]
    [MaxLength(40)]
    [JsonProperty("Name")]
    public string Name { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(40)]
    [JsonProperty("Nationality")]
    public string Nationality { get; set; }

    [Required]
    [JsonProperty("Type")]
    public string Type { get; set; }

    public int[] Trucks { get; set; }
}
