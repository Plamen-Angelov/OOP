using System;
using System.Linq;
using System.Collections.Generic;

namespace BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Ids = new List<string>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string id = input.Split().Last();
                Ids.Add(id);

                input = Console.ReadLine();
            }
            string fakeId = Console.ReadLine();

            foreach (var id in Ids)
            {
                if (id.EndsWith(fakeId))
                {
                    Console.WriteLine(id);
                }
            }
        }
    }
}
