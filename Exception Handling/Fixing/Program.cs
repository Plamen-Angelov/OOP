using System;

namespace Fixing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] weekdays = new string[5];
            weekdays[0] = "Wednesday";
            weekdays[1] = "Saturday";
            weekdays[2] = "Monday";
            weekdays[3] = "Tuesday";
            weekdays[4] = "Friday";

            try
            {
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine(weekdays[i]);
                }
            }
            catch (IndexOutOfRangeException ar)
            {
                Console.WriteLine(ar.Message);
            }
        }
    }
}
