using System;

namespace PizzaCalories
{
    public class Topping
    {
        private string type;
        private double weight;


        public string Type
        {
            get { return type; }
            set 
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" 
                    && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value; 
            }
        }

        public double Weight
        {
            get { return weight; }
            set 
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }
                weight = value; 
            }
        }

        public double Calories 
        { 
            get { return GetCalories(); } 
        }

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
        }


        private double GetCalories()
        {
            double toppingModifier = 0;

            switch (Type.ToLower())
            {
                case "meat":
                    toppingModifier = 1.2;
                    break;
                case "veggies":
                    toppingModifier = 0.8;
                    break;
                case "cheese":
                    toppingModifier = 1.1;
                    break;
                case "sauce":
                    toppingModifier = 0.9;
                    break;
            }

            return (2 * Weight * toppingModifier);
        }
    }
}
