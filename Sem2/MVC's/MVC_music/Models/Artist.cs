namespace MVC_music.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }

        //navigation property
        public ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
