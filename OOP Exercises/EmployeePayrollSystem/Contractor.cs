using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem
{
    public class Contractor : Employee
    {
        public Contractor(string name): base(name)
        {
            
        }
        public double hourlyRate { get; set; }
        public int hoursWorked { get; set; }
        public override double CalculateSalary()
        {
            return hourlyRate * hoursWorked;
        }
    }
}
