using System.ComponentModel.DataAnnotations;

namespace mvcECommerce.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required][StringLength(50)] public string OrderNumber { get; set; } = string.Empty; 
        public DateTime OrderDate { get; set; } // Navigation property: One Order has many OrderItems
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}
