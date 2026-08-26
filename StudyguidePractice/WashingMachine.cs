using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyguidePractice
{
    public class WashingMachine : Appliance
    {
        public override void TurnOn()
        {
            Console.WriteLine("Washing machine is now on.");
        }
    }
}
