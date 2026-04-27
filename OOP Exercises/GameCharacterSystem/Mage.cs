<<<<<<< HEAD
﻿using System;
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
=======
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
>>>>>>> dc12548130aeb50905ddce44b8ba16c469423f90
