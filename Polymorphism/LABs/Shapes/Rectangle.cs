using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public double Height 
        {
            get => height;
             private set 
             {
                if (value <= 0)
                {
                    throw new InvalidSideEXeption(GetMessage("Height"));
                }
                height = value;
            }
        }

        public double Width 
        {
            get => width;
            private set
            {
                if (value <= 0)
                {
                    throw new InvalidSideEXeption(GetMessage("width"));
                }
                width = value;
            }
        }

        public Rectangle(double hight, double width)
        {
            this.height = hight;
            this.width = width;
        }

        public override double CalculateArea()
        {
            return height * width;
        }

        public override double CalculatePerimeter()
        {
            return (2 * height) + (2 * width);
        }

        public override string Draw()
        {
            return $"{ this.GetType().Name}";
        }

        public string GetMessage(string side)
        {
            return $"{side} must be positive number";
        }
    }
}
