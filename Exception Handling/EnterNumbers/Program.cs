using System;

namespace EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    ReadNumber(start, end);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("The input should be a number");
            }
            catch (Exception)
            {
                Console.WriteLine("Unknown exception");
            }
        }

        public static void ReadNumber(int start, int end)
        {
            int number = int.Parse(Console.ReadLine());

            if (number < start || number > end)
            {
                throw new ArgumentException("Invalid input");
            }
        }
    }
}
