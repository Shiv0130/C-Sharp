using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem
{
    public class Student : Person
    {
        public override string GetRole()
        {
            return "Student";
        }        
    }
}
