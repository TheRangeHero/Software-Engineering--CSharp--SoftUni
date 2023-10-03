namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here

            string result = ExportSongsAboveDuration(context, 4);
            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();
            var albums = context.Albums
                .Where(a => a.ProducerId.HasValue && a.ProducerId.Value == producerId)
                .ToArray()
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                .Select(s => new
                {
                    SongName = s.Name,
                    Price = s.Price.ToString("f2"),
                    Writer = s.Writer.Name,
                })
                .OrderByDescending(s => s.SongName)
                .ThenBy(s => s.Writer)
                .ToArray(),
                    AlbumPrice = a.Price.ToString("f2"),
                }).ToArray();


            foreach (var a in albums)
            {
                sb
                     .AppendLine($"-AlbumName: {a.AlbumName}")
                     .AppendLine($"-ReleaseDate: {a.ReleaseDate}")
                     .AppendLine($"-ProducerName: {a.ProducerName}")
                     .AppendLine("-Songs:");


                    int songCounter = 1;
                foreach (var s in a.Songs)
                {
                    sb
                        .AppendLine($"---#{songCounter}")
                        .AppendLine($"---SongName: {s.SongName}")
                        .AppendLine($"---Price: {s.Price}")
                        .AppendLine($"---Writer: {s.Writer}");

                    songCounter++;
                }
                sb.AppendLine($"-AlbumPrice: {a.AlbumPrice}");
            }

            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();

            var songs = context.Songs
                .AsEnumerable()
                .Where(s => s.Duration.TotalSeconds > duration)                
                .OrderBy(s => s.Name).ThenBy(s => s.Writer)
                .Select(s => new
                {
                    SongName = s.Name,
                    Writer = s.Writer.Name,
                    Performer = s.SongPerformers.Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}").OrderBy(p => p).ToArray(),
                    AlbumProducer = s.Album!.Producer!.Name,
                    Duration = s.Duration.ToString("c")
                })
                .ToArray();


            int songCounter = 1;
            foreach (var s in songs)
            {
                sb
                    .AppendLine($"-Song #{songCounter}")
                    .AppendLine($"---SongName: {s.SongName}")
                    .AppendLine($"---Writer: {s.Writer}");

                foreach (var p in s.Performer)
                {
                    sb
                        .AppendLine($"---Performer: {p}");
                }

                sb
                    .AppendLine($"---AlbumProducer: {s.AlbumProducer}")
                    .AppendLine($"---Duration: {s.Duration}");

                songCounter++;
            }

            return sb.ToString().Trim();
        }
    }
}
