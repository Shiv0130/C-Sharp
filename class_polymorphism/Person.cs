using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_polymorphism
{
    public abstract class Person
    {
        //Encapsulation: only accessible within this class and derived classes
        protected string Name;

        public void SetName(string name) 
        {
            this.Name = name;
        }

        public string getName() 
        {
            return Name;
        }

        //Abstraction

        public abstract void DisplayRole();
    }
}
