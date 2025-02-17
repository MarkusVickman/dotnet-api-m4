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

        [Display(Name = "Utgivningsdatum")]
        public DateOnly ReleaseYear { get; set; }

        [Required]
        public required int ArtistId { get; set; }


        public Artist? Artist { get; set; }


        public List<Song>? Song { get; set; }

    }
}