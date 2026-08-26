using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleNotes
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Greet(string name, int age)
        {
            Console.WriteLine($"Hello My Name is {name}, and my age is {age}");
        }
    }
}
