<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pro741Exam
{
    public class Book : LibraryItem 
    {
        public int PageCount { get; set; }

        // how do i inherit the same constructor from the base class LibraryItem?
        // don't i say publi
        public Book(string title,string author,int pageCount) : base(title,author) 
        {
            PageCount = pageCount;

        }

        public override double CalculateFee(int daysLate) 
        {
            // For example, let's say the fee for a late book is $0.25 per day
            return daysLate * 0.25;
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pro741Exam
{
    public class Book : LibraryItem 
    {
        public int PageCount { get; set; }

        // how do i inherit the same constructor from the base class LibraryItem?
        // don't i say publi
        public Book(string title,string author,int pageCount) : base(title,author) 
        {
            PageCount = pageCount;

        }

        public override double CalculateFee(int daysLate) 
        {
            // For example, let's say the fee for a late book is $0.25 per day
            return daysLate * 0.25;
        }
    }
}
>>>>>>> f1fd9259c06725f9a30786509326a6e923171712
