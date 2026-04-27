<<<<<<< HEAD
﻿using System;
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
=======
﻿using System;
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
>>>>>>> dc12548130aeb50905ddce44b8ba16c469423f90
