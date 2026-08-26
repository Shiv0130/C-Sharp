using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem
{
    public abstract class Person
    {
        private string? name;
        public string? Name { get; set; }
    
    public abstract string GetRole();
    }
