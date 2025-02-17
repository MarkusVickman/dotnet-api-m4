using System.ComponentModel.DataAnnotations;
namespace MusicAPI.Models
{

    public class SongPutDto
    {

        public int SongId { get; set; }

        public string Title { get; set; }

        public int? Length { get; set; }

        public string? Category { get; set; }

        public int ArtistId { get; set; }

        public int AlbumId { get; set; }

    }
}