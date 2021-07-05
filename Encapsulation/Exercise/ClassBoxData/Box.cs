using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double lenght;
        private double width;
        private double height;


        public double Lenght
        {
            get { return lenght; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Lenght cannot be zero or negative.");
                }
                this.lenght = value; 
            }
        }


        public double Width
        {
            get { return width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }


        public double Height
        {
            get { return height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }


        public Box(double lenght, double width, double height)
        {
            Lenght = lenght;
            Width = width;
            Height = height;
        }

        public double GetSurfaceArea()
        {
            return (2 * Lenght * Width) + (2 * Lenght * Height) + (2 * Width * Height);


        } 

        public double GetLateralSurfaceArea()
        {
            return (2 * Lenght * Height) + (2 * Width * Height);
        }

        public double GetVolume()
        {
            return Lenght * Width * Height;
        }
    }
}
