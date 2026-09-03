namespace MVC_music.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation property: every Song by this artist.
        // Not an editable form field - songs are created/linked from the
        // Song side (picking an Artist from a dropdown), not typed in here.
        public ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
