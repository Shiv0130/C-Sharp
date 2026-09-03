using System.ComponentModel.DataAnnotations;

namespace MVC_music.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        [Display(Name = "Artist")]
        public int ArtistId { get; set; }

        // Navigation properties - nullable, no default instance.
        // FIX: Artist previously defaulted to "= new Artist();", which risked
        // EF silently inserting a phantom empty Artist row alongside every new
        // Song created via the form. Removed, and made nullable to match Genre.
        public Genre? Genre { get; set; }
        public Artist? Artist { get; set; }
    }
}
