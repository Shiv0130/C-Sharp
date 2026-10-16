using System.ComponentModel.DataAnnotations;

namespace Property24.Models
{
    public class Agent
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        // Navigation property: one agent lists many properties
        public ICollection<Property>? Properties { get; set; }
    }
}
