using System.ComponentModel.DataAnnotations;

namespace MusicAPI.Models
{

    //Dto för Artist tabellen som används för att bestämma krav put
    public class ArtistPutDto
    {

        [Required]
        public required int ArtistId { get; set; }

        [Required]
        public required string ArtistName { get; set; }

    }
}