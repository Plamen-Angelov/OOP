using System;

namespace ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string[] line = Console.ReadLine().Split();

                if (line[0] == "End")
                {
                    break;
                }

                string name = line[0];
                string country = line[1];
                int age = int.Parse(line[2]);
                IPerson citizen = new Citizen(name, country, age);
                Console.WriteLine($"{citizen.GetName()}");
                IResident resident = new Citizen(name, country, age);
                Console.WriteLine($"{resident.GetName()}");
            }
        }
    }
}
