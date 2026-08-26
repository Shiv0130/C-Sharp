using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem
{
    public abstract class Employee
    {
        protected string name;

        protected Employee(string name)
        {
            this.name = name;
        }

        public abstract double CalculateSalary();
    }
}

