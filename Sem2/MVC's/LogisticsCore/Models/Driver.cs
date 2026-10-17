namespace LogisticsCore.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string LicenseCode { get; set; } = string.Empty;
        public ICollection<DeliveryTruck> AssignedTrucks { get; set; } = new List<DeliveryTruck>();
    }
}