<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueExercises
{
    public class Person
    {
        public string Name { get; set; }
        public int TicketsNeeded { get; set; }

        /*
o They buy one ticket (decrease TicketsNeeded by 1).
o If TicketsNeeded > 0, re-enqueue that person.
o If TicketsNeeded == 0, they leave and are not re-added.
         */

        void BuyTicket()
        {
            if (TicketsNeeded > 0)
            {
                TicketsNeeded--;
                Console.WriteLine($"{Name} bought a ticket. Tickets needed now: {TicketsNeeded}");
            }
                if (TicketsNeeded == 0)
                {
                    Console.WriteLine($"{Name} bought a ticket and finished.");
            }
        }


    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueExercises
{
    public class Person
    {
        public string Name { get; set; }
        public int TicketsNeeded { get; set; }

        /*
o They buy one ticket (decrease TicketsNeeded by 1).
o If TicketsNeeded > 0, re-enqueue that person.
o If TicketsNeeded == 0, they leave and are not re-added.
         */

        void BuyTicket()
        {
            if (TicketsNeeded > 0)
            {
                TicketsNeeded--;
                Console.WriteLine($"{Name} bought a ticket. Tickets needed now: {TicketsNeeded}");
            }
                if (TicketsNeeded == 0)
                {
                    Console.WriteLine($"{Name} bought a ticket and finished.");
            }
        }


    }
}
>>>>>>> f1fd9259c06725f9a30786509326a6e923171712
