using _125_MusicLibraryBinusTask.Data;
using _125_MusicLibraryBinusTask.Model;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
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
            List<Song> songs = _context.Songs.ToList();
            return Ok(songs);
        }

        [HttpGet("{id}")]
        public IActionResult GetSong(int id)
        {
            Song song = _context.Songs.FirstOrDefault(f => f.Id == id);

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
    }
}
