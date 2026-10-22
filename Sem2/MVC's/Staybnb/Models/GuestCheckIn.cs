namespace Staybnb.Models
{
    public class GuestCheckIn
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public Booking? Booking { get; set; }
        public int? CheckInProcessId { get; set; }
        public CheckInProcess? CheckInProcess { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<GuestDocument> Documents { get; set; } = new List<GuestDocument>();
    }
}
