using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pizzaName = string.Empty;
            string flourType = string.Empty;
            string bakingTechnique = string.Empty;
            double doughWeight = 0;
            string toppingType = string.Empty;
            double toppingWeight = 0;
            Dough dough;
            List<Topping> toppings = new List<Topping>();


            while (input != "END")
            {
                string[] tokens = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0].ToLower())
                {
                    case "pizza":
                        pizzaName = tokens[1];
                        break;
                    case "dough":
                        flourType = tokens[1];
                        bakingTechnique = tokens[2];
                        doughWeight = double.Parse(tokens[3]);

                        try
                        {
                            dough = new Dough(flourType, bakingTechnique, doughWeight);
                        }
                        catch (ArgumentException ae)
                        {

                            Console.WriteLine(ae.Message);
                            Environment.Exit(0);
                        }

                        break;
                    case "topping":
                        toppingType = tokens[1];
                        toppingWeight = double.Parse(tokens[2]);

                        try
                        {
                            Topping topping = new Topping(toppingType, toppingWeight);
                            toppings.Add(topping);
                        }
                        catch (ArgumentException ae)
                        {

                            Console.WriteLine(ae.Message);
                            Environment.Exit(0);

                        }

                        break;
                }

                input = Console.ReadLine();
            }

            dough = new Dough(flourType, bakingTechnique, doughWeight);

            if (toppings.Count < 0 || toppings.Count > 10)
            {
                Console.WriteLine("Number of toppings should be in range [0..10].");
                Environment.Exit(0);
            }

            try
            {
                Pizza pizza = new Pizza(pizzaName, dough, toppings.ToArray());
                Console.WriteLine($"{pizza.Name} - {pizza.Calories:F2} Calories.");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                Environment.Exit(0);

            }
        }
    }
}
