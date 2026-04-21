using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSystem
{
    public abstract class Vehicle
    {
        protected int speed;

        public int Accelerate(int amount) 
        {
            speed += amount;
            return speed;
        }

        public abstract string Move();
    }
}
