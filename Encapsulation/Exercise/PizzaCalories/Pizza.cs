using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private readonly List<Topping> toppings = new List<Topping>();

        public string Name 
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }

        public Dough Dough { get; set; }

        public double Calories
        {
            get { return GetCalories(); }
        }

        public Pizza(string name, Dough dough, params Topping [] toppings)
        {
            Name = name;
            Dough = dough;
            this.toppings = AddToppings(toppings);
        }

        private List<Topping> AddToppings(object[] toppings)
        {
            foreach (Topping topping in toppings)
            {
                this.toppings.Add(topping);
            }
            return this.toppings;
        }

        private double GetCalories()
        {
            double doughCalories = Dough.Calories;
            double toppingsCalories = 0;

            if (toppings.Count > 0)
            {
                foreach (var topping in toppings)
                {
                    toppingsCalories += topping.Calories;
                }
            }

            return (doughCalories + toppingsCalories);
        }
    }
}
