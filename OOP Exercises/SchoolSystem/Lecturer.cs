using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem
{
    public class Lecturer : Person
    {
        public override string GetRole()
        {
            return "Lecturer";
        }
    }
}
