using System.ComponentModel.DataAnnotations;

namespace MusicAPI.Models
{

    public class ArtistPutDto
    {

        [Required]
        public required int ArtistId { get; set; }

        [Required]
        public required string ArtistName { get; set; }

    }
}