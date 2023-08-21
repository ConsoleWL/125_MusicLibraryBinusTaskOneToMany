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

        //[HttpGet("{id}")]
        //public IActionResult GetPlaylist(int id)
        //{
        //    Playlist? playlist = _context.Playlists.SingleOrDefault(f => f.PlaylistId == id);

        //    if (playlist is null)
        //        return NotFound();

        //    var playlistWithSongs = _context.Playlists
        //        .Include(f=>f.Songs.)
        //}
       
    }
}
