using _125_MusicLibraryBinusTask.Data;
using _125_MusicLibraryBinusTask.Model;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace _125_MusicLibraryBinusTask.Controllers
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

        [HttpGet]
        public IActionResult GetSongs()
        {
            List<Song> songsAndPlaylist = _context.Songs
                .Include(f => f.Playlist) // added  that then i had this error when i tried to get all songs with playlistId
                                          // Newtonsoft.Json.JsonSerializationException: Self referencing loop detected with type '_125_MusicLibraryBinusTask.Model.Song'. Path '[0].playlist.songs'.0
                                          // Then I added ReferenceLoopHandling.Ignore; in Program.cs file  and error was gone.
                                          // but now for some reason I'm getting a list of songs in that playlist it's probobly  because of that property  public Playlist? Playlist { get; set; } in class Song; 
                                          // something is not right;
                .ToList();

            return Ok(songsAndPlaylist);
        }

        [HttpGet("{id}")]
        public IActionResult GetSong(int id)
        {
            Song? song = _context.Songs
                .Include(f => f.Playlist)
                .FirstOrDefault(f => f.Id == id);
                                       

            if (song is null)
                return NotFound();

            return Ok(song);
        }

        [HttpPost]
        public IActionResult SongAdd([FromBody] Song song)
        {
            if (song is null)
                return BadRequest(400);

            _context.Songs.Add(song);
            _context.SaveChanges();
            return Ok(song);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSong(int id, [FromBody] Song newSong)
        {
            Song? song = _context.Songs.FirstOrDefault(f => f.Id == id);

            if (song is null)
                return NotFound($"Not Found Song with this {id}");

            song.Title = newSong.Title;
            song.Artist = newSong.Artist;
            song.Album = newSong.Album;
            song.ReleaseDate = newSong.ReleaseDate;
            song.Genre = newSong.Genre;
            song.Likes = newSong.Likes;

            _context.SaveChanges();
            return Ok(song);
        }

        

        [HttpPatch("{id}")]
        public IActionResult UpdatePartialSong(int id, [FromBody] JsonPatchDocument<Song> patchSong)
        {
            if (patchSong is null)
                BadRequest();

            Song? song = _context.Songs.FirstOrDefault(f => f.Id == id);

            if (song is null)
                return NotFound($"Can not find a song with id {id}");

            Song? newSong = new Song
            {
                Id = song.Id,
                Title = song.Title,
                Album = song.Album,
                ReleaseDate = song.ReleaseDate,
                Genre = song.Genre,
                Likes = song.Likes
            };

            // I see a lot ModelState stuff. would be nice to get to know this "Creature" better 
            patchSong.ApplyTo(newSong, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            song.Title = newSong.Title;
            song.Album = newSong.Album;
            song.ReleaseDate = newSong.ReleaseDate;
            song.Genre = newSong.Genre;
            song.Likes = newSong.Likes;

            _context.SaveChanges();

            return Ok(song);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSong(int id)
        {
            Song? song = _context.Songs.FirstOrDefault(f => f.Id == id);

            if (song is null)
                return NotFound($"Not Found Song With id {id}");

            _context.Songs.Remove(song);
            _context.SaveChanges();

            return Ok(song);
        }

        [HttpPut("like/{id}")]
        public IActionResult LikeSong(int id)
        {
            Song? song = _context.Songs.FirstOrDefault(f => f.Id == id);

            if (song is null)
                return NotFound();

            song.Likes++;
            _context.SaveChanges();

            return Ok(song);
        }

        //4. Create an endpoint on the SongsController that allows you to add a Song to a
        // Playlist.One way to do this is to have a PlaylistId passed through the request URL
    }
}
