/*My Code
using System.ComponentModel.DataAnnotations;

namespace mvc_BloggingPlatform.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        [Required]
        [StringLength(100)]
        public string Bio { get; set; }
        [StringLength(500)]
        //naviagation property
        public ICollection<BlogPost> BlogPost { get; set; } = new List<BlogPost>();
        
    }
}*/

//Corrected Code
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mvc_BloggingPlatform.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(500)]
        public string? Bio { get; set; }

        // Navigation property
        public ICollection<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();
    }
}
