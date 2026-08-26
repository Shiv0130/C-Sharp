using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Employees
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public double salary { get; set; }

        public Employees(int id, string Name, string Surname, double Salary)
        {
            name = Name;
            surname = Surname;
            salary = Salary;
            ID = id;

        }

        public void DisplayEmployeeInfo()
        {
            Console.WriteLine($"Employee ID: {ID}");
            Console.WriteLine($"Employee Name: {name}");
            Console.WriteLine($"Employee Surname: {surname}");
            Console.WriteLine($"Employee Salary: R{salary}");
        }

    }
}