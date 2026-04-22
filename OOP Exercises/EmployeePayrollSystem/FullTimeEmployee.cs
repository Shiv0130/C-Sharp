using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem
{
    public class FullTimeEmployee : Employee
    {
        public FullTimeEmployee(string name):base(name)
        {
            
        }
        public double monthlySalary { get; set; }
        public override double CalculateSalary()
        {
            
            return monthlySalary;
        }
    }
}
