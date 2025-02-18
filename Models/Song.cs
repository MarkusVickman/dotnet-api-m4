using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MusicAPI.Models
{

    /*Model för Tabell Song. Många kollumner mer lite enklare inställning. Innehåller FK från tabell Album och Artist. JSON Ignore för att inte post-anropet ska fastna i en loop */
    public class Song
    {

        //PK
        public int SongId { get; set; }

        [Required]
        public required string Title { get; set; }

        public int? Length { get; set; }

        public string? Category { get; set; }

        //FK
        [Required]
        public required int? ArtistId { get; set; }

        //Navigeringsegenskap
        public Artist? Artist { get; set; }

        //FK
        public int? AlbumId { get; set; }

        //Navigeringsegenskap
        [JsonIgnore]
        public Album? Album { get; set; }
    }
}