using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcVehicle.Models
{
    public class GpsTracker
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string SerialNumber { get; set; } = string.Empty;

        public DateTime InstalledDate { get; set; }

        //Required Foreign Key
        public int VehicleId { get; set; }

        // Navigation proprty back to Vehicle
        [ForeignKey("VehicleId")]
        public Vehicle? Vehicle { get; set; } = null!;
    }
}
