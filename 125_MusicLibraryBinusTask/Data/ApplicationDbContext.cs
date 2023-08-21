using _125_MusicLibraryBinusTask.Model;
using Microsoft.EntityFrameworkCore;

namespace _125_MusicLibraryBinusTask.Data
{
    public class ApplicationDbContext : DbContext
    {
        public  DbSet<Playlist> Playlists { get; set; }
        public DbSet<Song> Songs{ get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
            //base.OnModelCreating(modelBuilder);

            

            //Playlist nikitaS = new Playlist()
            //{
            //    PlaylistId = 1,
            //    Name = "Nikita's",
            //};

            //Playlist crystal = new Playlist()
            //{
            //    PlaylistId = 2,
            //    Name = "Crystal's"
            //};

            //Playlist tomS = new Playlist()
            //{
            //    PlaylistId = 3,
            //    Name = "TomS"
            //};

            

            //Song WhoisWho = new Song()
            //{
            //    Id = 1,
            //    Title = "Who is Who",
            //    Artist = "Who",
            //    Album = "When",
            //    ReleaseDate = DateTime.Now,
            //    Genre = "Alternative",
            //    Like = 0
            //};
            //Song Rasputin = new Song()
            //{
            //    Id = 2,
            //    Title = "Rasputin",
            //    Artist = "Boney M",
            //    Album = "Long Time Ago",
            //    ReleaseDate = DateTime.Now,
            //    Genre = "80's",
            //    Like = 0
            //};
            //Song BadPoetry = new Song()
            //{
            //    Id = 3,
            //    Title = "Bad Poetry",
            //    Artist = "Eminem",
            //    Album = "Shady",
            //    ReleaseDate = DateTime.Now,
            //    Genre = "Rap",
            //    Like = 0
            //};
            //Song Jimmi = new Song()
            //{
            //    Id = 4,
            //    Title = "Jimmi",
            //    Artist = "Cury",
            //    Album = "Spicy Year",
            //    ReleaseDate = DateTime.Now,
            //    Genre = "Folk",
            //    Like = 0
            //};
            //Song RustyNail = new Song()
            //{
            //    Id = 5,
            //    Title = "Rusty Nails",
            //    Artist = "Scre Driver",
            //    Album = "My Neighbours Never Sleep",
            //    ReleaseDate = DateTime.Now,
            //    Genre = "Heavy Metall",
            //    Like = 0,
            //    //Playlist = 1,
            //    //PlaylistId =
            //};

            

            

            //modelBuilder.Entity<Song>().HasData(
            //    new Song
            //    {
            //        Id = 1,
            //        Title = "Who is Who",
            //        Artist = "Who",
            //        Album = "When",
            //        ReleaseDate = DateTime.Now,
            //        Genre = "Alternative",
            //        Like = 0

            //    },
            //    new Song
            //    {
            //        Id = 2,
            //        Title = "Rasputin",
            //        Artist = "Boney M",
            //        Album = "Long Time Ago",
            //        ReleaseDate = DateTime.Now,
            //        Genre = "80's",
            //        Like = 0
            //    },
            //    new Song
            //    {
            //        Id = 3,
            //        Title = "Bad Poetry",
            //        Artist = "Eminem",
            //        Album = "Shady",
            //        ReleaseDate = DateTime.Now,
            //        Genre = "Rap",
            //        Like = 0
            //    },
            //    new Song
            //    {
            //        Id = 4,
            //        Title = "Jimmi",
            //        Artist = "Cury",
            //        Album = "Spicy Year",
            //        ReleaseDate = DateTime.Now,
            //        Genre = "Folk",
            //        Like = 0
            //    },
            //    new Song
            //    {
            //        Id = 5,
            //        Title = "Rusty Nails",
            //        Artist = "Scre Driver",
            //        Album = "My Neighbours Never Sleep",
            //        ReleaseDate = DateTime.Now,
            //        Genre = "Heavy Metall",
            //        Like = 0,
            //        Playlist = 1,
            //        PlaylistId = 

            //    }) ;

            //modelBuilder.Entity<Playlist>().HasData(
            //    new Playlist
            //    {
            //        PlaylistId = 1,
            //        Name = "Nikita's"
            //    },
            //    new Playlist
            //    {
            //        PlaylistId = 2,
            //        Name = "Crystal's"
            //    },
            //    new Playlist
            //    {
            //        PlaylistId =3,
            //        Name = "Tom's"
            //    });
        //}
    }
}
