using System;
using System.Collections.Generic;

namespace WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            List<Food> foods = new List<Food>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] animalInfo = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string type = animalInfo[0];
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);

                string[] foodInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string foodType = foodInfo[0];
                int foodQuantity = int.Parse(foodInfo[1]);

                if (foodType == "Vegetable")
                {
                    foods.Add(new Vegetable(foodQuantity));
                }
                else if (foodType == "Fruit")
                {
                    foods.Add(new Fruit(foodQuantity));
                }
                else if (foodType == "Meat")
                {
                    foods.Add(new Meat(foodQuantity));
                }
                else if (foodType == "Seeds")
                {
                    foods.Add(new Seeds(foodQuantity));
                }

                if (type == "Cat")
                {
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];
                    animals.Add(new Cat(name, weight, 0, livingRegion, breed));
                }
                else if (type == "Tiger")
                {
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];
                    animals.Add(new Tiger(name, weight, 0, livingRegion, breed));
                }
                else if (type == "Owl")
                {
                    double wingSize = double.Parse(animalInfo[3]);
                    animals.Add(new Owl(name, weight, 0, wingSize));
                }
                else if (type == "Hen")
                {
                    double wingSize = double.Parse(animalInfo[3]);
                    animals.Add(new Hen(name, weight, 0, wingSize));
                }
                else if (type == "Mouse")
                {
                    string livingRegion = animalInfo[3];
                    animals.Add(new Mouse(name, weight, 0, livingRegion));
                }
                else if (type == "Dog")
                {
                    string livingRegion = animalInfo[3];
                    animals.Add(new Dog(name, weight, 0, livingRegion));
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < animals.Count; i++)
            {
                animals[i].AskForFood();
                animals[i].Eat(foods[i]);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
