using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Person {

        public string name { get; set; }
        public int age { get; set; }

        public Person(string Name, int Age) {
            name = Name;
            age = Age;
        }
        

        public void Greet()
        {
            Console.WriteLine($"Hello my name is {name} and I'm {age} years old.");
        }
    }       
}
