using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFlow
{
    public class Passenger
    {
        public int Passengerid;
        public int UserId { get; set; }
        public string PassportNumber { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
       public string Nationality { get; set; } = "";
        public string? ContactNumber { get; set; }
        
        //Navigation - filled when joining Users table
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string FullName => $"{FirstName} {LastName}".Trim();

    }

}
