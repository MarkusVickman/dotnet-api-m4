using System.ComponentModel.DataAnnotations;

namespace MusicAPI.Models
{

    public class AlbumDto
    {

        [Required]
        [Display(Name = "Albumnamn")]
        public required string AlbumName { get; set; }


        [Display(Name = "Utgivningsdatum")]
        public DateOnly ReleaseYear { get; set; }

        [Required]
        public required int ArtistId { get; set; }

    }
}