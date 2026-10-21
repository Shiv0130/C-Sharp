namespace Staybnb.Models
{
    public class HostProperty
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PropertyType { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public string HostId { get; set; } = string.Empty;
        public ApplicationUser? Host { get; set; }

        public ICollection<PropertyImage> Images { get; set; } = new List<PropertyImage>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Amenity> Amenities { get; set; } = new List<Amenity>();
        public CheckInProcess? CheckInProcess { get; set; }
    }
}