namespace MVC_music.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        //navigation property
        public ICollection<Song> Songs { get; set; } = new List<Song>();

    }
}
