using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MusicAPI.Models
{

    public class Song
    {

        public int SongId { get; set; }

        [Required]
        public required string Title { get; set; }

        public int? Length { get; set; }

        public string? Category { get; set; }

        [Required]
        public required int? ArtistId { get; set; }
        
        public Artist? Artist { get; set; }

        public int? AlbumId { get; set; }

        [JsonIgnore]
        public Album? Album { get; set; }
    }
}