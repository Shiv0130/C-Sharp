using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacterSystem
{ 
    public abstract class Character
    {
        protected int health;

        public void SetHealth() 
        {
            this.health = 0;
        }

        public void TakeDamage(int amount)
        {
            if (amount  >= 0)
            {
                health -= amount;
                Console.WriteLine("You have taken damage. Current health " + health);
            }
            else
            {
                Console.WriteLine("Health cannot go below 0.");
            }
        }
        public abstract string Attack();

            
        }
    }
