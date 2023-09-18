namespace CarDealer.DTOs.Import;

using Newtonsoft.Json;

public class ImportCustomerDTO
{
    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("birthDate")]
    public string BirthDate { get; set; }

    [JsonProperty("isYoungDriver")]
    public bool IsYoungDriver { get; set; }
}
