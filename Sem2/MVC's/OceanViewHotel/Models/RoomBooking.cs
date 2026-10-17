namespace OceanViewHotel.Models
{
    public class RoomBooking
    {
        public int Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public decimal TotalCharge { get; set; }
        public int HotelRoomId { get; set; }
        public HotelRoom? HotelRoom { get; set; }
        public int GuestId { get; set; }
        public Guest? Guest { get; set; }
    }
}