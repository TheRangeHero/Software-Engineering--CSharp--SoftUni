﻿namespace CarDealer.DTOs.Import;

using Newtonsoft.Json;

public class ImportSalesDTO
{
    [JsonProperty("carId")]
    public int CarId { get; set; }

    [JsonProperty("customerId")]
    public int CustomerId { get; set; }

    [JsonProperty("discount")]
    public decimal  Discount { get; set; }
}
