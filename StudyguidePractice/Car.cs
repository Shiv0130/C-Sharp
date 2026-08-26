using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace StudyguidePractice
{
    public class Car: Vehicle
    {
        public int Doors { get; set; }

        public Car(string make, string model, int doors) : base(make, model) 
        {
            Doors = doors;
        }
    }
}
