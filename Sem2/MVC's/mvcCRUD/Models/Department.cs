using System.ComponentModel.DataAnnotations;

namespace mvcCRUD.Models
{
    // Represents a department, which can have many Employees (one-to-many).
    public class Department
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]

        // Navigation property for related Employees.
        // Initialized to an empty list so it's never null before employees are loaded/added.
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
