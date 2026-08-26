// We will create a new class to show you more:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroCodeBasics
{
    public class Human
    {
        public String name;
        public int age;

        public void Eat()
        {
            Console.WriteLine(name + " is eating");
        }
        public void Sleep()
        {
            Console.WriteLine(name + " is sleeping");
        }
    }
}