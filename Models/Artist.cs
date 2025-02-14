using System.ComponentModel.DataAnnotations;

namespace MusicAPI.Models
{

    public class Artist
    {

        public int ArtistId { get; set; }

        [Required]
        public required string ArtistName { get; set; }

        public List<Album>? Album { get; set; }

        public List<Song>? Song { get; set; }
    }
}