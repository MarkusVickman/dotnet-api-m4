using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MusicAPI.Models
{

    public class Artist
    {

        public int ArtistId { get; set; }

        [Required]
        public required string ArtistName { get; set; }

        [JsonIgnore]
        public List<Album>? Album { get; set; }

        [JsonIgnore]
        public List<Song>? Song { get; set; }
    }
}