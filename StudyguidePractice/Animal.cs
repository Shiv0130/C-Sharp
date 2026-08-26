using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyguidePractice
{
    public class Animal
    {
        //public string Name { get; set; }
        //private int Age;
        //protected string Species;

        public virtual void Speak() 
        {
            Console.WriteLine("Animal speaks");
        }
    }

   


}
