<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pro741Exam
{
    public class DVD : LibraryItem
    {
        public int DurationInMinutes { get; set; }


        public DVD(string title, string author, int durationInMinutes) : base(title, author)
        {
            DurationInMinutes = durationInMinutes;
        }

        public override double CalculateFee(int daysLate)
        {
            // For example, let's say the fee for a late DVD is $0.50 per day
            return daysLate * 0.50;
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pro741Exam
{
    public class DVD : LibraryItem
    {
        public int DurationInMinutes { get; set; }


        public DVD(string title, string author, int durationInMinutes) : base(title, author)
        {
            DurationInMinutes = durationInMinutes;
        }

        public override double CalculateFee(int daysLate)
        {
            // For example, let's say the fee for a late DVD is $0.50 per day
            return daysLate * 0.50;
        }
    }
}
>>>>>>> f1fd9259c06725f9a30786509326a6e923171712
