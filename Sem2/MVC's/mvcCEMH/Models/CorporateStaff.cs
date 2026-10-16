using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcCEMH.Models
{
    public class CorporateStaff
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string JobTitle { get; set; } = string.Empty;

        public int? ManagerId { get; set; }

        [ForeignKey("ManagerId")]
        public CorporateStaff? Manager { get; set; }

        public ICollection<CorporateStaff> DirectReports { get; set; } = new List<CorporateStaff>();
    }
}