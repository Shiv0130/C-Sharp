using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystem
{
    public class Pizza : FoodItem
    {
        public Pizza(double price) : base(price) 
        {
            
        }

        public override string Prepare()
        {
            return "Baking pizza";
        }
    }
}
