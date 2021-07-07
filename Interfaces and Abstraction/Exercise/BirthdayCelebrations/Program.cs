using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<IBirtheble> collection = new List<IBirtheble>();

            while (input != "End")
            {
                string[] tokens = input.Split();
                string name = tokens[1];

                if (tokens[0] == "Citizen")
                {
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string birthDate = tokens[4];

                    IBirtheble citizen = new Citizen(name, age, id, birthDate);
                    collection.Add(citizen);
                }
                else if (tokens[0] == "Pet")
                {
                    string birthDate = tokens[2];

                    IBirtheble pet = new Pet(name, birthDate);
                    collection.Add(pet);
                }
                input = Console.ReadLine();
            }

            string year = Console.ReadLine();

            foreach (var item in collection)
            {
                if (item.BirthDate.EndsWith(year))
                {
                    Console.WriteLine(item.BirthDate);
                }
            }
        }
    }
}
