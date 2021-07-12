using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Rectangle rectangle = new Rectangle(5, 4);
                Circle circle = new Circle(5);

                Console.WriteLine(rectangle.CalculatePerimeter());
                Console.WriteLine(rectangle.CalculateArea());
                Console.WriteLine(circle.CalculatePerimeter());
                Console.WriteLine(circle.CalculateArea());
            }
            catch (InvalidRadiusExeption re)
            {
                Console.WriteLine(re.Message);
            }
            catch (InvalidSideEXeption se)
            {
                Console.WriteLine(se.Message);
            }
        }
    }
}
