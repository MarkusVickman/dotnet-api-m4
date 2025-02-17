using System.ComponentModel.DataAnnotations;

namespace MusicAPI.Models
{

    public class ArtistDto
    {

        [Required]
        public required string ArtistName { get; set; }

    }
}