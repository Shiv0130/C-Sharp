namespace Staybnb.Models
{
    public class WishListItem
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser? User { get; set; }
        public int PropertyId { get; set; }
        public HostProperty? Property { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}