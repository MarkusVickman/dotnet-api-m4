using System.ComponentModel.DataAnnotations;

namespace MusicAPI.Models
{

    //Dto för Artist tabellen som används för att bestämma krav post
    public class ArtistDto
    {

        [Required]
        public required string ArtistName { get; set; }

    }
}