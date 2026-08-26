using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingSystem
{
    public abstract class Product
    {
        //protected double price;
        //public double Price => price;
        //or
        public double price { get; protected set; }
        public Product(double price) 
        {
            this.price = price;
        }

        public abstract double CalculateDiscount();
    }
}
