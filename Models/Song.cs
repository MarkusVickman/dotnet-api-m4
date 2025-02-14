using System.ComponentModel.DataAnnotations;
namespace MusicAPI.Models
{

    public class Song
    {

        public int SongId { get; set; }

        [Required]
        public required string Title { get; set; }

        public int Lenght { get; set; }

        public string? Category { get; set; }

        public int? ArtistId { get; set; }

        [Required]
        public required Artist Artist { get; set; }

        public int? AlbumId { get; set; }
        
        public Album? Album { get; set; }
    }
}