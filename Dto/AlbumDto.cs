using System.ComponentModel.DataAnnotations;

namespace MusicAPI.Models
{

    //Dto för Album tabellen som används för att bestämma krav post
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