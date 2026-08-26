using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacterSystem
{
    public class Warrior : Character 
    {
        //correction - added constructor to set health for Warrior
        public Warrior(int health) : base(health) 
        {
            
        }
        public override string Attack()
        {
            return "Warrior swings a sword";
        }
    }
}
