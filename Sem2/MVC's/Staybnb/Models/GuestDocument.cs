namespace Staybnb.Models
{
    public class GuestDocument
    {
        public int Id { get; set; }
        public int GuestCheckInId { get; set; }
        public GuestCheckIn? GuestCheckIn { get; set; }
        public string DocumentType { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";
    }
}