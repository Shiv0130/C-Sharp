using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem
{
    //public class Contractor : Employee
    //{
    //    public Contractor(string name) : base(name)
    //    {

    //    }
    //    public double hourlyRate { get; set; }
    //    public int hoursWorked { get; set; }
    //    public override double CalculateSalary()
    //    {
    //        return hourlyRate * hoursWorked;
    //    }
    //}

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
=======
﻿using System;
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
