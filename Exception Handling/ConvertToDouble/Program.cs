using System;

namespace ConvertToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string input = Console.ReadLine();
                double num = Convert.ToDouble(input);
                Console.WriteLine(num);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);

            }
            catch (InvalidCastException ce)
            {
                Console.WriteLine(ce.Message);

            }
        }
    }
}
