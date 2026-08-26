using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_7
{
    public abstract class Character
    {
        protected int health;

        public Character(int health)
        {
            this.health = health;
        }

        public void TakeDamage(int amount) {
            if (this.health > 0 && health >= amount)
            {
                health = -amount;
            }
        }

        public abstract string Attack();

    }
}
