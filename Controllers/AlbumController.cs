using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicAPI.Data;
using MusicAPI.Models;

namespace MusicAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AlbumController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Album
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
        {
            //Inkluderar artister och songer som har fk i album
            var albums = await _context.Albums
                .Include(a => a.Artist)
                .Include(a => a.Song)
                .ToListAsync();

            if (albums == null)
            {
                return NotFound();
            }

            return albums;
        }

        // GET: api/Album/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {
            //Inkluderar artister och songer som har fk i album
            var album = await _context.Albums
                .Include(a => a.Artist)
                .Include(a => a.Song)
                .FirstOrDefaultAsync(a => a.AlbumId == id);

            if (album == null)
            {
                return NotFound();
            }

            return album;
        }

        // PUT: api/Album/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlbum(int id, AlbumPutDto albumPutDto)
        {
            if (id != albumPutDto.AlbumId)
            {
                return BadRequest();
            }

            var album = await _context.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            //Flera if-satser som gör att bara om fälten är ifyllda så uppdateras värdet i databasen
            if (albumPutDto.ArtistId != 0)
            {
                if (albumPutDto.ArtistId != 0)
                {
                    var artist = await _context.Artists.FindAsync(albumPutDto.ArtistId);
                    if (artist == null)
                    {
                        return NotFound($"Album with ID {albumPutDto.ArtistId} not found.");
                    }

                    album.ArtistId = albumPutDto.ArtistId;
                }
            }

            // Uppdatera endast fält som skickas med i begäran
            if (!string.IsNullOrEmpty(albumPutDto.AlbumName))
            {
                album.AlbumName = albumPutDto.AlbumName;
            }

            if (albumPutDto.ReleaseYear != default)
            {
                album.ReleaseYear = albumPutDto.ReleaseYear;
            }

            // Kontrollerar om fel uppstår vid sparande till databasen
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Album
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Album>> PostAlbum(AlbumDto albumDto)
        {

            //Kontrollerar om tillhörande artist finns
            var artist = await _context.Artists.FindAsync(albumDto.ArtistId);
            if (artist == null)
            {
                return NotFound($"Artist with ID {albumDto.ArtistId} not found.");
            }

            //Sparar värden från Dto till Album objekt
            var newEntry = new Album
            {
                AlbumName = albumDto.AlbumName,
                ReleaseYear = albumDto.ReleaseYear,
                Artist = artist,
                ArtistId = albumDto.ArtistId
            };

            //Sparar objektet till databasen
            _context.Albums.Add(newEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlbum", new { id = newEntry.AlbumId }, newEntry);
        }

        // DELETE: api/Album/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.AlbumId == id);
        }
    }
}
