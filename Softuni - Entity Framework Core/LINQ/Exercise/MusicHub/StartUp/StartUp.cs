namespace MusicHub
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();
            var albums = context.Albums
                .Include(x=>x.Songs)
                .ThenInclude(x=>x.Writer)
                .Where(x => x.ProducerId == producerId)
                .Select(album => new
                {
                    album.Name,
                    ReleaseDate = album
                    .ReleaseDate
                    .ToString("MM/dd/yyyy"),
                    ProducerName = album.Producer.Name,
                    album.Songs,
                    album.Price
                })
                .OrderByDescending(x => x.Price)
                .ToList();

            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine($"-Songs:");
                var songs = album
                    .Songs
                    .Select(song => new
                {
                    SongName = song.Name,
                    song.Price,
                    WriterName = song.Writer.Name
                })
                .OrderByDescending(x => x.SongName)
                .ThenBy(x => x.WriterName);

                int counter = 1;
                foreach (var song in songs.ToList())
                {
                    sb.AppendLine($"---#{counter}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.Price:f2}");
                    sb.AppendLine($"---Writer: {song.WriterName}");
                    counter++;
                }
                sb.AppendLine($"-AlbumPrice: {album.Price:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();

            var songs = context
                .Songs
                .Include(x => x.SongPerformers)
                .ThenInclude(x => x.Performer)
                .Where(x => x.Duration.CompareTo(
                    new TimeSpan(0, 0, duration)) > 0)
                .Select(x => new
                {
                    x.Name,
                    x.SongPerformers,
                    WriterName = x.Writer.Name,
                    AlbumProducer = x.Album.Producer.Name,
                    Duration = x.Duration.ToString("c")
                })
                .ToList();

            int counter = 1;
            foreach (var song in songs
                .OrderBy(x => x.Name)
                .ThenBy(x => x.WriterName))
            {
                sb.AppendLine($"-Song #{counter}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.WriterName}");
                if (song.SongPerformers.Count > 0)
                {
                    foreach (var songPerformer in song
                        .SongPerformers
                        .OrderBy(x => x.Performer.FirstName
                        + x.Performer.LastName))
                    {
                        sb.AppendLine($"---Performer: " +
                            $"{songPerformer.Performer.FirstName + " " + songPerformer.Performer.LastName}");
                    }
                }
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration}");

                counter++;
            }

            return sb.ToString().Trim();
        }
    }
}
