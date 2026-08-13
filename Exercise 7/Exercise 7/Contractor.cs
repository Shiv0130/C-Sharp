using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_7
{
    public class Contractor : Employee
    {
        private double hourlyRate;
        private int hoursWorked;

        public Contractor(string name, double rate, int hours) : base(name)
        {
            hourlyRate = rate;
            hoursWorked = hours;
        }

        public override double CalculateSalary()
        {
            return hourlyRate * hoursWorked;
        }
    }
}
