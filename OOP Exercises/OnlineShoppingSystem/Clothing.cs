using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingSystem
{
    public class Clothing : Product
    {
        public Clothing(double price) : base(price) 
        {
            
        }

        public override double CalculateDiscount()
        {
            return price * 0.85; // 15% discount for clothing   
        }
    }
}
