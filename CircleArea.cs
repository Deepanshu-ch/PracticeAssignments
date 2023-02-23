using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfCircle
{
    class CircleArea
    {
        readonly double radius;
        public CircleArea()
        {
            Console.Write("Enter Radius:");
            _ = double.TryParse(Console.ReadLine(), out radius);
        }
        public CircleArea(double radius)
        {
            this.radius = radius;
        }
        public double Area() => Math.Pow(radius, 2) * Math.PI;
    }
}
