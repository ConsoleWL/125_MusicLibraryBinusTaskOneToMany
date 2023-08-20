using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _125_MusicLibraryBinusTask.Model
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public int Like { get; set; }

        [ForeignKey("PlayList")]
        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
    }
}
