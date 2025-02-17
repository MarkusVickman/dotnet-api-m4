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
    public class SongController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SongController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Song
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            var songs = await _context.Songs
                          .Include(a => a.Artist)
                          .Include(a => a.Album)
                          .ToListAsync();

            if (songs == null)
            {
                return NotFound();
            }

            return songs;
        }

        // GET: api/Song/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(int id)
        {

            var song = await _context.Songs
                .Include(a => a.Artist)
                .Include(a => a.Album)
                .FirstOrDefaultAsync(a => a.SongId == id);

            if (song == null)
            {
                return NotFound();
            }

            return song;
        }

        // PUT: api/Song/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong(int id, SongPutDto songPutDto)
        {
            if (id != songPutDto.SongId)
            {
                return BadRequest();
            }

            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            if (songPutDto.AlbumId != 0)
            {
                // Uppdatera endast fält som skickas med i begäran
                if (songPutDto.AlbumId != 0)
                {
                    var album = await _context.Albums.FindAsync(songPutDto.AlbumId);
                    if (album == null)
                    {
                        return NotFound($"Album with ID {songPutDto.AlbumId} not found.");
                    }

                    song.AlbumId = songPutDto.AlbumId;
                }
            }

            if (songPutDto.ArtistId != 0)
            {
                if (songPutDto.ArtistId != 0)
                {
                    var artist = await _context.Artists.FindAsync(songPutDto.ArtistId);
                    if (artist == null)
                    {
                        return NotFound($"Album with ID {songPutDto.ArtistId} not found.");
                    }

                    song.ArtistId = songPutDto.ArtistId;
                }
            }

            // Uppdatera endast fält som skickas med i begäran
            if (!string.IsNullOrEmpty(songPutDto.Title))
            {
                song.Title = songPutDto.Title;
            }

            if (songPutDto.Length.HasValue)
            {
                song.Length = songPutDto.Length.Value;
            }

            if (!string.IsNullOrEmpty(songPutDto.Category))
            {
                song.Category = songPutDto.Category;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
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

        // POST: api/Song
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(SongDto songDto)
        {



            var artist = await _context.Artists.FindAsync(songDto.ArtistId);
            if (artist == null)
            {
                return NotFound($"Artist with ID {songDto.ArtistId} not found.");
            }

            var album = await _context.Albums.FindAsync(songDto.AlbumId);

            var newEntry = new Song
            {
                Title = songDto.Title,
                AlbumId = songDto.AlbumId,
                Artist = artist,
                ArtistId = songDto.ArtistId,
                Length = songDto.Length,
                Category = songDto.Category,

            };

            _context.Songs.Add(newEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSong", new { id = newEntry.SongId }, newEntry);
        }

        // DELETE: api/Song/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SongExists(int id)
        {
            return _context.Songs.Any(e => e.SongId == id);
        }
    }
}
