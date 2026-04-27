using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem
{
    //public class FullTimeEmployee : Employee
    //{
    //    public double monthlySalary { get; set; }
    //    public FullTimeEmployee(string name) : base(name)
    //    {

    //    }

    //    public override double CalculateSalary()
    //    {

    //        return monthlySalary;
    //    }
    //}

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