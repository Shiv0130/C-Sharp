using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_polymorphism
{
    public class Teacher : Person 
    {
        //Polymorphism (method override)
        public override void DisplayRole() 
        {
            Console.WriteLine($"I am a Teacher. My name is {Name}");
        
        }
    }
}
