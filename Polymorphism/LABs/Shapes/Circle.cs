using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public double Radius 
        {
            get => radius;
            private set
            {
                if (value <= 0)
                {
                    throw new InvalidRadiusExeption();
                }
                radius = value;
            }
        }

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override string Draw()
        {
            return $"{this.GetType().Name}";
        }
    }
}
