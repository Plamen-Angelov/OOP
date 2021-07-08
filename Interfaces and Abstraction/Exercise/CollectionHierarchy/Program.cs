using System;

namespace CollectionHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemove = new AddRemoveCollection();
            MyList list = new MyList();

            string[] line = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < line.Length; i++)
            {
                Console.Write($"{addCollection.Add(line[i])} ");
            }
            Console.WriteLine();

            for (int i = 0; i < line.Length; i++)
            {
                Console.Write($"{addRemove.Add(line[i])} ");
            }
            Console.WriteLine();


            for (int i = 0; i < line.Length; i++)
            {
                Console.Write($"{list.Add(line[i])} ");
            }
            Console.WriteLine();


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write($"{addRemove.Remove()} ");
            }
            Console.WriteLine();


            for (int i = 0; i < n; i++)
            {
                Console.Write($"{list.Remove()} ");
            }
            Console.WriteLine();
        }
    }
}
