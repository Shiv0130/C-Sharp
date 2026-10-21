namespace Staybnb.Models
{
    public class CheckInProcess
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public HostProperty? Property { get; set; }
        public string Title { get; set; } = string.Empty;
        public string StepsJson { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}