using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebels = new List<Rebel>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine()
                    .Split();
                string name = info[0];
                int age = int.Parse(info[1]);

                if (info.Length == 4)
                {
                    string id = info[2];
                    string birthDate = info[3];

                    Citizen citizen = new Citizen(name, age, id, birthDate);
                    citizens.Add(citizen);
                }
                else if (info.Length == 3)
                {
                    string group = info[2];

                    Rebel rabel = new Rebel(name, age, group);
                    rebels.Add(rabel);
                }
            }

            string inputName = Console.ReadLine();
            int purchasedFood = 0;

            while (inputName != "End")
            {
                if (citizens.Any(c => c.Name == inputName))
                {
                    purchasedFood += 10;
                }
                else if (rebels.Any(r => r.Name == inputName))
                {
                    purchasedFood += 5;
                }
                inputName = Console.ReadLine();
            }
            Console.WriteLine(purchasedFood);
        }
    }
}
