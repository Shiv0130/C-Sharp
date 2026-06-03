using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFlow
{
    public class GateAgent : User
    {
        public GateAgent()
        {
            Role = "GateAgent";

        }

        // Override - GateAgent sees boarding/ check-in menu
        public override void DisplayDashboard()
        {
            Console.WriteLine("     GATE AGENT DASHBOARD         ");
            Console.WriteLine("  1. View Flight Manifest              ");
            Console.WriteLine("  2. Passenger Check-In              ");
            Console.WriteLine("  3. Update Flight Status                       ");
            Console.WriteLine("  4. Logout                       ");
        }
    }
}
