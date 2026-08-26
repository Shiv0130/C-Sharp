using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleNotes
{
    public class Student
    {
        public string? StudentNumber { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Qualification { get; set; }

        public Student(string studentnumber, string name, string surname, string qualification)
        {
            StudentNumber = studentnumber;
            Name = name;
            Surname = surname;
            Qualification = qualification;
        }

        public void DisplayStudentDetails(Student student)
        {
            Console.WriteLine($"Student Number: {student.StudentNumber}");
            Console.WriteLine($"Student Name: {student.Name}");
            Console.WriteLine($"Student Surname: {student.Surname}");
            Console.WriteLine($"Student Qualification: {student.Qualification}");
        }
    }
}
