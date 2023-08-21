using _125_MusicLibraryBinusTask.Data;
using _125_MusicLibraryBinusTask.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace _125_MusicLibraryBinusTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PlaylistController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPlaylists()
        {
            List<Playlist> playlists = _context.Playlists.ToList();
            return Ok(playlists);
        }

        [HttpGet("{id}")]
        public IActionResult GetPlaylist(int id)
        {
            Playlist? playlist = _context.Playlists.Include(f=>f.Songs)
                                                   .SingleOrDefault(f => f.PlaylistId == id);

            if (playlist is null)
                return NotFound();

            return Ok(playlist);
        }

        [HttpPost]
        public IActionResult AddPlaylist([FromBody] Playlist playlist)
        {
            if (playlist is null)
                return BadRequest();

            _context.Playlists.Add(playlist);
            _context.SaveChanges();
            return Ok(playlist);

            // What if I want to Add a playlist with list of songs??
            // Probobly that has to be done in json just expend those brackets and add song id in it???
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePlaylist(int id, [FromBody] Playlist newPlaylist)
        {
            Playlist? playlist = _context.Playlists.FirstOrDefault(f => f.PlaylistId == id);

            if (playlist is null)
                return NotFound();

            playlist.Name = newPlaylist.Name;
            playlist.Songs = newPlaylist.Songs; // I don't know should i include this or not but it's getting interesting..
                                                // how would logic go....do we  want to get a new playlist or just add few songs...
                                                // or delete a song from our playlist??
                                                // for now i just leave it as it is. Maybe change it later
            _context.SaveChanges();
            return Ok(playlist);

        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlaylist(int id)
        {
            Playlist? playlist = _context.Playlists.FirstOrDefault(f => f.PlaylistId == id);

            if (playlist is null)
                return NotFound();

            _context.Playlists.Remove(playlist);
            _context.SaveChanges();
            return Ok(playlist);
        }
    }
}
