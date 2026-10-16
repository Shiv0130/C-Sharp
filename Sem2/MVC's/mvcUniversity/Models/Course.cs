using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcUniversity.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string CourseCode { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;

        //Foreign key
        public int FacultyId { get; set; }

        //Navigation property back to Faculty
        [ForeignKey("FacultyId")]
        public Faculty? Faculty { get; set; }


    }
}
