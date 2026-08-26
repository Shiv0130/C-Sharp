/* My Code
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc_BloggingPlatform.Models
{
    public class BlogPost
    {
        [Key]
        public int BlogId { get; set; }
        
        public string Title { get; set; }
        [Required]

        public string Content { get; set; }
        [Required]
        [StringLength(200)]
        public DateTime PublishDate { get; set; }
        public int AuthorId { get; set; }
        [ForeignKey("Author")]
        //navigation property
        public Author Author { get; set; }
    }
} */

// Corrected Code
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc_BloggingPlatform.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        // Navigation property
        public Author Author { get; set; }
    }
}