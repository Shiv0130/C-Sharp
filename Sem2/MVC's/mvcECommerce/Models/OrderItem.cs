using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace mvcECommerce.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        //Foreign Key
        public int OrderId { get; set; }

        //Navigation property back to order
        [ForeignKey("OrderId")]
        public Order? Order { get; set; }
    }

}
