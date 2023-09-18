namespace Theatre.DataProcessor;

using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using Theatre.Data;
using Theatre.DataProcessor.ExportDto;

public class Serializer
{
    public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
    {

        var theatersExport = context.Theatres
            .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count() >= 20)
            .Select(t => new
            {
                t.Name,
                Halls = t.NumberOfHalls,
                TotalIncome = t.Tickets.Where(x => x.RowNumber >= 1 && x.RowNumber <= 5).Sum(x => x.Price),
                Tickets = t.Tickets.Where(x => x.RowNumber >= 1 && x.RowNumber <= 5).Select(t => new
                {
                    t.Price,
                    t.RowNumber
                })
                .OrderByDescending(x => x.Price)
                .ToArray()
            })
            .OrderByDescending(h => h.Halls)
            .ThenBy(n => n.Name);

        string json = JsonConvert.SerializeObject(theatersExport, Formatting.Indented);
        return json;
    }


    
    public static string ExportPlays(TheatreContext context, double raiting)
    {
        StringBuilder sb = new StringBuilder();

        XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
        XmlSerializer serializer = new XmlSerializer(typeof(XMLExportPlayDto[]), xmlRoot);

        XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
        xmlns.Add(string.Empty, string.Empty);

        using StringWriter writer = new StringWriter(sb);



        var result = context.Plays
            .Where(p => p.Rating <= raiting)
            .ToArray()
            .OrderBy(p => p.Title)
            .ThenByDescending(p => p.Genre)
            .Select(p => new XMLExportPlayDto
            {
                Title = p.Title,
                Duration = p.Duration.ToString("c", CultureInfo.InvariantCulture), 
                Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                Genre = p.Genre.ToString(),
                Actors = p.Casts.Where(x => x.IsMainCharacter)
                .Select(a => new XMLExportActorDto
                {
                    FullName = a.FullName,
                    MainCharacter = $"Plays main character in '{p.Title}'."
                })
                .OrderByDescending(x => x.FullName)
                .ToArray()
            })                
            .ToArray();



        serializer.Serialize (writer, result,xmlns);
        return sb.ToString().TrimEnd();
    }
}
