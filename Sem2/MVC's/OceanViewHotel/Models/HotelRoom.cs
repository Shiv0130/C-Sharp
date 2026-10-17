namespace OceanViewHotel.Models
{
    public class HotelRoom
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public string RoomType { get; set; } = string.Empty;
        public decimal BaseRatePerNight { get; set; }
        public ICollection<RoomBooking> Bookings { get; set; } = new List<RoomBooking>();
    }
}