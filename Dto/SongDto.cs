using System.ComponentModel.DataAnnotations;
namespace MusicAPI.Models
{

    //Dto för Song tabellen som används för att bestämma krav post
    public class SongDto
    {
        [Required]
        public required string Title { get; set; }

        public int? Length { get; set; }

        public string? Category { get; set; }

        [Required]
        public required int? ArtistId { get; set; }

        public int? AlbumId { get; set; }

    }
}