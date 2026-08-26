using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcOfficeDeskAssign.Models
{
    public class DeskAssignment
    {
        [Key]
        public int DeskAssignId { get; set; } //Primary Key
        [Required]
        [StringLength(10)]
        public string? DeskNumber { get; set; }

        public int AssignDate { get; set; }

        // Foreign Key
        [ForeignKey("Employee")]
        public int EmpId { get; set; }

        //navigation property(one-to-one relationship)
        public Employee? Employee { get; set; }

    }
}
