using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_7
{
    public class Warrior : Character
    {
        public Warrior(int health) : base(health) { }

        public override string Attack()
        {
            return "Warrior swings a sword";
        }
    }
}
