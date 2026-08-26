using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFlow
{
    public class Flight
    {
        public int FlightId { get; set; }
        //  added = "" - compiler warned non-nullable has no default
        public string FlightNumber { get; set; } = "";
        public string Origin { get; set; } = "";
        public string Destination { get; set; } = "";
        public DateTime DepartureTime { get; set; }
        //  ArrivalTime can be null in DB
        public DateTime? ArrivalTime { get; set; }
        public int Capacity { get; set; }
        public int CurrentOccupancy { get; set; }
        public int? GateAgentId { get; set; } // Nullable for unassigned flights

        // Encapsulation: Status is private - outside code cannot set it directly
        // They MUST go through SetBoarding() or DepartFlight()
        private string _status = "Scheduled";
        public string Status => _status; // read-only from outside

        // Controlled status change methods
        public bool SetBoarding()
        {

            if (_status == "Scheduled")
            {
                _status = "Boarding";
                return true;
            }
            Console.WriteLine("Flight must be Scheduled before it can board.");
            return false;
        }


        public bool DepartFlight()
        {
            if (_status == "Boarding")
            {
                _status = "Departed";
                return true;
            }
            Console.WriteLine("Flight must be Boarding before it can depart.");
            return false;
        }

        // Used when loading from DB - Dapper maps Status column value to this
        public void SetStatusFromDb(string status) => _status = status;


        public bool IsFull => CurrentOccupancy >= Capacity;
    }
}