namespace Footballers.DataProcessor.ImportDto;


using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

public class ImportJsonTeams
{
    [Required]
    [MinLength(3)]
    [MaxLength(40)]
    [JsonProperty("Name")]
    public string Name { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(40)]
    [JsonProperty("Nationality")]
    public string Nationality { get; set; }

    
    [JsonProperty("Trophies")]
    public int Trophies { get; set; }

    [JsonProperty("Footballers")]
    public int[] Footballers { get; set; }
}
