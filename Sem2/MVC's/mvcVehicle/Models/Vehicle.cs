using System.ComponentModel.DataAnnotations;

namespace mvcVehicle.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string LicensePlate { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Model { get; set; } = string.Empty;

        // Navigation property: One-to-One
        public GpsTracker? GpsTracker { get; set; }


    }
}
