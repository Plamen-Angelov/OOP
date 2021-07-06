using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public void Draw()
        {
            Console.WriteLine(new string('*', Width));
            for (int i = 1; i <= Height - 2; i++)
            {
                Console.WriteLine($"*{new string(' ', Width-2)}*");
            }
            Console.WriteLine(new string('*', Width));
        }
    }
}
