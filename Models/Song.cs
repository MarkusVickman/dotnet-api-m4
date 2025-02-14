using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MusicAPI.Models
{

    public class Song
    {

        public int SongId { get; set; }

        [Required]
        public required string Title { get; set; }

        public int Lenght { get; set; }

        public string? Category { get; set; }

        [Required]
        public required int? ArtistId { get; set; }

        public Artist? Artist { get; set; }

        public int? AlbumId { get; set; }
        
        public Album? Album { get; set; }
    }
}