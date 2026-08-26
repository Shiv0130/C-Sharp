<<<<<<< HEAD
﻿using System;
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
=======
﻿using System;
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
>>>>>>> f1fd9259c06725f9a30786509326a6e923171712
