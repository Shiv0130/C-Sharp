using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyguidePractice
{
    public abstract class Appliance
    {
        public string Brand { get; set; }

        public abstract void TurnOn();
    }
}
