using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFlow
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int FlightId { get; set; }
        public int PassengerId { get; set; }
        public string SeatNumber { get; set; } = "";

        public string BookingStatus { get; set; } = "Confirmed"; // Default to Confirmed

        public DateTime BookingDate { get; set; }
        public DateTime? CheckInTime { get; set; }

        public DateTime? BoardingTime { get; set; }

        //Navigation properties 
        public string PassengerName { get; set; } = "";
        public string PassportNumber { get; set; } = "";
        public string FlightNumber { get; set; } = "";

    }
}
