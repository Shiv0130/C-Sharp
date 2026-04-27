using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystem
{
    public abstract class FoodItem
    {
        public double price { get; protected set; }

        protected FoodItem(double price)
        {
            this.price = price;
        }

        public abstract string Prepare();
    }
}
