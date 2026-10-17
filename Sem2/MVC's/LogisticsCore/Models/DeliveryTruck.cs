namespace LogisticsCore.Models
{
    public class DeliveryTruck
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public double OdometerKm { get; set; }
        public decimal MaxPayloadKg { get; set; }
        public int DepotId { get; set; }
        public TruckDepot? Depot { get; set; }
        public int DriverId { get; set; }
        public Driver? Driver { get; set; }
    }
}