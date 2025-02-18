using System.ComponentModel.DataAnnotations;

namespace MusicAPI.Models
{

    public class AlbumPutDto
    {

        //Dto för Album tabellen som används för att bestämma krav put
        public int AlbumId { get; set; }

        public string? AlbumName { get; set; }

        [Display(Name = "Utgivningsdatum")]
        public DateOnly ReleaseYear { get; set; }

        public int ArtistId { get; set; }

    }
}