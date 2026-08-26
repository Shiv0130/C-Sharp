using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcMovieWatchList.Models
{
    public class WatchListEntry
    {
        [Key]
        public int WatchListId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public int Rating { get; set; }

        public DateTime WatchedDate { get; set; }

        //navigation properties
        public User? User { get; set; }
        public Movie? Movie { get; set; }
    }
}
