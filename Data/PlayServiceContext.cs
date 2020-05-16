using Microsoft.EntityFrameworkCore;
using PlayService.Models;

namespace PlayService.Data {
    public class PlayServiceContext : DbContext {
        public PlayServiceContext(DbContextOptions<PlayServiceContext> options) :base (options) {

        }

        // Override OnModelCreating in DBContext and tell it to use Pgcrypto for GUID colloumn.
        protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);
                builder.HasPostgresExtension("pgcrypto");
            }

        public DbSet<Artist> Artists {get; set;}
        public DbSet<Album> Albums {get; set;}
        public DbSet<Song> Songs {get; set;}
        public DbSet<Playlist> Playlists {get; set;}
        public DbSet<Genre> Genres {get; set;}

    }
}