using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSystem
{
    public class Car : Vehicle
    {
        public override string Move()
        {
            return "Car is driving";
        }
    }
}
