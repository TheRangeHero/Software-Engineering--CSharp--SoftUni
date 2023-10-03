﻿using System.Xml.Serialization;

namespace CarDealer.DTOs.Import;

[XmlType("Customer")]
public class ImportCustomerDto
{
    [XmlElement("name")]
    public string Name { get; set; } = null!;

    [XmlElement("birthDate")]
    public string BirthDate { get; set; }

    [XmlElement("isYoungerDriver")]
    public bool IsYoungDriver { get; set; }
}
