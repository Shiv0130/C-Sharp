using System.ComponentModel.DataAnnotations;

namespace mvcMovieWatchList.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }// Primary Key
        [Required]
        [StringLength(50)]
        public string? UserName { get; set; }

        public DateTime MembershipDate { get; set; }

        //navigation property between user and movie
        public ICollection<WatchListEntry>? WatchListEntries { get; set; }
    }
}
