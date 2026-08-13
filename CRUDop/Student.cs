using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDop
{
    public class Student
    {
        public int StudentID { get; set; }   // maps to primary key
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}
