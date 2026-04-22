using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacterSystem
{
    public class Mage : Character
    {
        //correction - added constructor to set health for Mage
        public Mage(int health) : base(health)
        {

        }
        public override string Attack() 
        {
            return "Mage casts a fireball";
        }
    }
}
