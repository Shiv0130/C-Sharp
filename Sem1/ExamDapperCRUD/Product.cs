<<<<<<< HEAD
﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ExamDapperCRUD
//{
//    public class Product
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public double Price { get; set; }
//        public int Stock { get; set; }

//    }
//}

//correction:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDapperCRUD
{
    public class Product
    {
        public int Id { get; set; }
        // FIX: added = string.Empty
        // Without this the compiler warns "Non-nullable property must 
        // contain a non-null value when exiting constructor"
        // string.Empty means it defaults to "" instead of null
        public string Name { get; set; } = string.Empty;
        // FIX: changed from double to decimal
        // The SQL table defines Price as DECIMAL(10,2)
        // decimal is the correct C# type for money/currency values
        // double can have floating point precision errors with money
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
=======
﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ExamDapperCRUD
//{
//    public class Product
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public double Price { get; set; }
//        public int Stock { get; set; }

//    }
//}

//correction:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDapperCRUD
{
    public class Product
    {
        public int Id { get; set; }
        // FIX: added = string.Empty
        // Without this the compiler warns "Non-nullable property must 
        // contain a non-null value when exiting constructor"
        // string.Empty means it defaults to "" instead of null
        public string Name { get; set; } = string.Empty;
        // FIX: changed from double to decimal
        // The SQL table defines Price as DECIMAL(10,2)
        // decimal is the correct C# type for money/currency values
        // double can have floating point precision errors with money
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
>>>>>>> f1fd9259c06725f9a30786509326a6e923171712
