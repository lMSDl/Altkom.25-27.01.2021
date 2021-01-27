using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleApp.SOLID
{
    abstract class Shape
    {
        public abstract double Area();
    }

    class Square : Shape
    {
        public int A { get; set; }

        public override double Area()
        {
            return A * A;
        }
    }

    class Rectangle : Shape
    {
        public int A { get; set; }
        public int B { get; set; }

        public override double Area()
        {
            return A * B;
        }
    }

    class Circle : Shape
    {
        public int R { get; set; }

        public override double Area()
        {
            return R * R * Math.PI;
        }
    }

    class ShapeCalculator
    {
        double Area(Shape shape)
        {
            return shape.Area();
        }
    }
}
