using System.ComponentModel.DataAnnotations;

namespace mvcMovieWatchList.Models
{
    public class Movie
    {
        public int MovieId { get; set; } //Primary Key
        [Required]
        
        public string? Title { get; set; }

        [Range(1900, 2026)]
        public int ReleaseYear { get; set; } = 0;

        //navigation property between user and movie
        public ICollection<WatchListEntry>? WatchListEntries { get; set; }

    }
}
