using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int level = int.Parse(Console.ReadLine());
            DarkKnight darkKnight = new DarkKnight(name, level);
            Console.WriteLine(darkKnight);
        }
    }
}
