using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_polymorphism
{
    public class Student : Person
    {
        //Polymorphism (override)
        public override void DisplayRole()
        {
            Console.WriteLine($"I am a Student. My name is {Name}");
        }
    }
}
