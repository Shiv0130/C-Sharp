using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystem
{
    public class Burger : FoodItem
    {
        public Burger(double price) : base(price) 
        {
            
        }

        public override string Prepare()
        {
            return "Grilling burger";
        }

    }

}
