namespace OceanViewHotel.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string PassportOrId { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        public ICollection<RoomBooking> Bookings { get; set; } = new List<RoomBooking>();
    }
}