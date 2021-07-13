using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        private const double weightIncreaseByEating = 0.35;
        public Hen(string name, double weight, int foodEaten, double wingSize) 
            : base(name, weight, foodEaten, wingSize)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("Cluck");
        }

        public override void Eat(Food food)
        {
            Weight += weightIncreaseByEating * food.Quantity;
            FoodEaten += food.Quantity;
        }
    }
}
