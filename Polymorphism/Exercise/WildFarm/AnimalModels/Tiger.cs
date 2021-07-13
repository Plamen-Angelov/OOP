﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    class Tiger : Feline
    {
        private const double weightIncreaseByEating = 1.00;

        public Tiger(string name, double weight, int foodEaten, string livingRegion, string breed) 
            : base(name, weight, foodEaten, livingRegion, breed)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("ROAR!!!");
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name == "Meat")
            {
                Weight += weightIncreaseByEating * food.Quantity;
                FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ToString()
        {
            return $"{ GetType().Name} [{ Name}, { Breed}, { Weight}, { LivingRegion}, { FoodEaten}]";
        }
    }
}
