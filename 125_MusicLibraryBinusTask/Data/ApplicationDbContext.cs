using _125_MusicLibraryBinusTask.Model;
using Microsoft.EntityFrameworkCore;

namespace _125_MusicLibraryBinusTask.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Song> Songs{ get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Song>().HasData(
                new Song
                {
                    Id = 1,
                    Title = "Who is Who",
                    Artist = "Who",
                    Album = "When",
                    ReleaseDate = DateTime.Now,
                    Genre = "Alternative",
                    Like = 0
                    
                },
                new Song
                {
                    Id = 2,
                    Title = "Rasputin",
                    Artist = "Boney M",
                    Album = "Long Time Ago",
                    ReleaseDate = DateTime.Now,
                    Genre = "80's",
                    Like = 0
                },
                new Song
                {
                    Id = 3,
                    Title = "Bad Poetry",
                    Artist = "Eminem",
                    Album = "Shady",
                    ReleaseDate = DateTime.Now,
                    Genre = "Rap",
                    Like = 0
                },
                new Song
                {
                    Id = 4,
                    Title = "Jimmi",
                    Artist = "Cury",
                    Album = "Spicy Year",
                    ReleaseDate = DateTime.Now,
                    Genre = "Folk",
                    Like = 0
                },
                new Song
                {
                    Id = 5,
                    Title = "Rusty Nails",
                    Artist = "Scre Driver",
                    Album = "My Neighbours Never Sleep",
                    ReleaseDate = DateTime.Now,
                    Genre = "Heavy Metall",
                    Like = 0
                });
        }
    }
}
