using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyguidePractice
{
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override void CalculateArea() 
        {
           double area = Width * Height;
              Console.WriteLine($"Area of the rectangle: {area}");
        }
    }
}
