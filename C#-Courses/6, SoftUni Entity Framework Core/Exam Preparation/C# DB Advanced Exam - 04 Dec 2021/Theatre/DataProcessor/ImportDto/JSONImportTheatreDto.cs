namespace Theatre.DataProcessor.ImportDto;

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


public class JSONImportTheatreDto
{
    [JsonProperty("Name")]
    [Required]
    [MinLength(4)]
    [MaxLength(30)]
    public string Name { get; set; }

    [JsonProperty("NumberOfHalls")]
    [Required]
    [Range(1,10)]
    public sbyte NumberOfHalls { get; set; }

    [JsonProperty("Director")]
    [Required]
    [MinLength(4)]
    [MaxLength(30)]
    public string Director { get; set; }

    [JsonProperty("Tickets")]
    public JSONImportTicketDto[] Tickets { get; set; }
}
