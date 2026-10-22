namespace Staybnb.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public HostProperty? Property { get; set; }
        public string GuestId { get; set; } = string.Empty;
        public ApplicationUser? Guest { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Payment? Payment { get; set; }
        public GuestCheckIn? GuestCheckIn { get; set; }
    }
}
