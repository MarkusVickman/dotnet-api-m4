using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MusicAPI.Models
{

    public class Artist
    {

        public int ArtistId { get; set; }

        [Required]
        public required string ArtistName { get; set; }

    }
}