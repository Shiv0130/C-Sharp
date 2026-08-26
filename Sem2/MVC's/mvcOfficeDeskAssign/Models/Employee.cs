using System.ComponentModel.DataAnnotations;

namespace mvcOfficeDeskAssign.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; } //Primary Key

        [Required]
        public string? Name { get; set; }

        public DateTime HireDate { get; set; }

        //navigation property (one-to-one relationship)
        public DeskAssignment? DeskAssignment { get; set; }

    }
}
