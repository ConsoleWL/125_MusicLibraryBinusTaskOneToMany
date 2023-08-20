using System.ComponentModel.DataAnnotations;

namespace _125_MusicLibraryBinusTask.Model
{
    public class Playlist
    {
        [Key]
        public int PlaylistId { get; set; }
        public string Name { get; set; }
        public ICollection<Song>  Songs { get; set; }

    }
}
