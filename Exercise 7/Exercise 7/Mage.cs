using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_7
{
    public class Mage : Character
    {
        public Mage(int health): base(health) { }

        public override string Attack()
        {
            return "Mage casts a fireball";
        }
    }
}
