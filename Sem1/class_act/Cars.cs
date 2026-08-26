//Cars class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_act
{
    public class Car
    {
        public string? Model { get; set; }
        public double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }

        public Car(string model, double fuelConsumption, double tankCapacity)
        {
            Model = model;
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
        }

        public double CalculateMaxDistance()
        {
            return (TankCapacity / FuelConsumption) * 100;
        }

        public double FuelNeeded(double distance)
        {
            return (distance / 100) * FuelConsumption;
        }

        public bool IsWeekendTrip(DateTime tripDate)
        {
            return tripDate.DayOfWeek switch
            {
                DayOfWeek.Saturday or DayOfWeek.Sunday => true,
                _ => false
            };
        }

    }
}