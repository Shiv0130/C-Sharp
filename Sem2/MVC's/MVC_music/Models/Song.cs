namespace MVC_music.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public string Title { get; set; }

        public int GenreId { get; set; }

        public int ArtistId { get; set; }

        //navigation properties
        public Genre Genre { get; set; }
        public Artist Artist { get; set; } = new Artist();
    }
}
