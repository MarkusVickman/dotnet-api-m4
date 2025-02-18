using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MusicAPI.Models
{

/*Model för Tabell Artist. ArtistId används som FK i Album samt Song*/
    public class Artist
    {
        //PK
        public int ArtistId { get; set; }

        [Required]
        public required string ArtistName { get; set; }

    }
}