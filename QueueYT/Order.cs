<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueYT
{
    public class Order
    {
        //order ID
        public int OrderId { get; set; }

        //quantity of the order
        public int OrderQuantity { get; set; }

        //simple constructor
        public Order(int id,int orderQuantity)
        {
            OrderId = id;
            OrderQuantity = orderQuantity;
        }
        public void ProcessOrder()
        {
            //print the message
            Console.WriteLine($"Order {OrderId} processed!");
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueYT
{
    public class Order
    {
        //order ID
        public int OrderId { get; set; }

        //quantity of the order
        public int OrderQuantity { get; set; }

        //simple constructor
        public Order(int id,int orderQuantity)
        {
            OrderId = id;
            OrderQuantity = orderQuantity;
        }
        public void ProcessOrder()
        {
            //print the message
            Console.WriteLine($"Order {OrderId} processed!");
        }
    }
}
>>>>>>> f1fd9259c06725f9a30786509326a6e923171712
