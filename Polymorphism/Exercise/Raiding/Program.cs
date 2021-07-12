using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Hero> raidGroup = new List<Hero>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    Hero hero = new Hero(heroType, heroName);
                    raidGroup.Add(hero);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            int bossPower = int.Parse(Console.ReadLine());

            foreach (var hero in raidGroup)
            {
               Console.WriteLine(hero.CastAbility());
            }

            int heroesPower = raidGroup
                .Sum(h => h.Power);

            if (heroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
