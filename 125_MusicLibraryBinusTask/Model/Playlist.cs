using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace _125_MusicLibraryBinusTask.Model
{
    public class Playlist
    {
        [Key]
        public int PlaylistId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Song>?  Songs { get; set; }

        // what is the difference between ICollection and List<T>  and when to use each?
    }
}
