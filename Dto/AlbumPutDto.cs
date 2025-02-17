using System.ComponentModel.DataAnnotations;

namespace MusicAPI.Models
{

    public class AlbumPutDto
    {

        public int AlbumId { get; set; }

        public string? AlbumName { get; set; }

        [Display(Name = "Utgivningsdatum")]
        public DateOnly ReleaseYear { get; set; }

        public int ArtistId { get; set; }

    }
}