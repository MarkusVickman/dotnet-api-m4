using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MusicAPI.Models
{

    /*Model för Tabell Album. Många kollumner mer lite enklare inställning. Innehåller FK från tabell Artist*/
    public class Album
    {

        //PK
        public int AlbumId { get; set; }

        [Required]
        [Display(Name = "Albumnamn")]
        public required string AlbumName { get; set; }

        [Display(Name = "Utgivningsdatum")]
        public DateOnly ReleaseYear { get; set; }

        //FK
        [Required]
        public required int ArtistId { get; set; }

        //Navigeringsegenskap
        public Artist? Artist { get; set; }

        //Navigeringsegenskap
        public List<Song>? Song { get; set; }

    }
}