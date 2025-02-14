using System.ComponentModel.DataAnnotations;

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

        public int? ArtistId { get; set; }

        [Required]
        public required Artist Artist { get; set; }

        public List<Song>? Song { get; set; }

    }
}