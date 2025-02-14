using Microsoft.EntityFrameworkCore;
using MusicAPI.Models;

namespace MusicAPI.Data;

//inställningar för DbContext, inkluderar databastabeller.
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Album> Albums { get; set; }

    public DbSet<Artist> Artists { get; set; }

    public DbSet<Song> Songs { get; set; }

}