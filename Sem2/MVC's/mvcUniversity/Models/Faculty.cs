using System.ComponentModel.DataAnnotations;

namespace mvcUniversity.Models
{
    public class Faculty
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FacultyName { get; set; } = string.Empty;

        [StringLength(20)]
        public string OfficeRoom { get; set; } = string.Empty;

        // Navigation property: One Faculty has many Courses
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
