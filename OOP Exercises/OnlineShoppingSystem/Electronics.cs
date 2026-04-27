using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingSystem
{
    public class Electronics : Product 
        
    {
        public Electronics(double price) : base(price) 
        {
            
        }
        public override double CalculateDiscount()
        {
            return price * 0.95; // 5% discount for electronics
        }

    }
}
