using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyguidePractice
{
    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override void CalculateArea()
        {
            double area = Math.PI * Radius * Radius;
            Console.WriteLine($"Area of the circle: {area}");
        }
    }
}
