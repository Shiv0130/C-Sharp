using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Property24.Models
{
    public class Property
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;

        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }

        // Foreign Keys
        [Display(Name = "Property Type")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; } 

        [Display(Name = "Listing Agent")]
        public int AgentId { get; set; }
        public Agent? Agent { get; set; }
    }
}

