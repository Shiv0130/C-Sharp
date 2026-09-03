namespace MVC_music.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation property: every Song in this genre.
        // Not an editable form field - same reasoning as Artist.Songs.
        public ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
