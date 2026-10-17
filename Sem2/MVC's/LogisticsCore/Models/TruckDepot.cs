namespace LogisticsCore.Models
{
    public class TruckDepot
    {
        public int Id { get; set; }
        public string DepotName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public ICollection<DeliveryTruck> Trucks { get; set; } = new List<DeliveryTruck>();
    }
}