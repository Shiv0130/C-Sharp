using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleNotes
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public double Salary { get; set; }

        public Employee(int id, string name, string surname, double salary)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Salary = salary;
        }

        public void DisplayEmployeeDetails(Employee employee)
        {
            Console.WriteLine($"Employee ID: {employee.Id}");
            Console.WriteLine($"Employee Name: {employee.Name}");
            Console.WriteLine($"Employee Surname: {employee.Surname}");
            Console.WriteLine($"Employee Salary: {employee.Salary}");
        }
        

    }
}
