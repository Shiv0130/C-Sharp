using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_7
{
    public class FullTimeEmployee : Employee
    {
        private double monthlySalary;

        public FullTimeEmployee(string name, double salary) : base(name)
        {
            monthlySalary = salary;
        }

        public override double CalculateSalary()
        {
            return monthlySalary;
        }
    }
}
