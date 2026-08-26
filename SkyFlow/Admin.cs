using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFlow
{
    public class Admin : User
    {
        public Admin()
        {
            Role = "Admin";
        }

        //Override - Admin sees flight management menu
        public override void DisplayDashboard() 
        {
           
            Console.WriteLine("     ADMIN DASHBOARD         ");
            Console.WriteLine("  1. Manage Flights           ");
            Console.WriteLine("  2. View System Overview     ");
            Console.WriteLine("  3. Manage Staff             ");
            Console.WriteLine("  4. Logout                   ");
            

        }
    }
}
