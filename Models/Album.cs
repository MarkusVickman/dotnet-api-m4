using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MusicAPI.Models
{

    public class Album
    {

        public int AlbumId { get; set; }

        [Required]
        [Display(Name = "Albumnamn")]
        public required string AlbumName { get; set; }

        [Required]
        [Display(Name = "Utgivningsdatum")]
        public DateOnly ReleaseYear { get; set; }

        public int ArtistId { get; set; }

        [JsonIgnore]
        public Artist? Artist { get; set; }

        [JsonIgnore]
        public List<Song>? Song { get; set; }

    }
}