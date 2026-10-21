namespace Staybnb.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public HostProperty? Property { get; set; }
        public string ReviewerId { get; set; } = string.Empty;
        public ApplicationUser? Reviewer { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}