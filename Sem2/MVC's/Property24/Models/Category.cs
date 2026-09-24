using System.ComponentModel.DataAnnotations;

namespace Property24.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Property Type")]
        public string Name { get; set; } = string.Empty;

        // Navigation property: one category has many properties
        public ICollection<Property>? Properties { get; set; }
    }
}
