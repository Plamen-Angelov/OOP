using System;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public string FlourType
        {
            get { return flourType; }
            set 
            {
                if (value.ToLower() == "white" || value.ToLower() == "wholegrain")
                {
                    flourType = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }


        public string BakingTechnique
        {
            get { return bakingTechnique; }
            set 
            {
                if (value.ToLower() == "crispy" || value.ToLower() == "chewy" || value.ToLower() == "homemade")
                {
                    bakingTechnique = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }


        public double Weight
        {
            get { return weight; }
            set 
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range[1..200].");
                }
                weight = value; 
            }
        }

        public double Calories
        {
            get
            {
                return GetCalories();
            }
       }

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        private double GetCalories()
        {
            double doughModifier = 0;
            double bakingModifier = 0;

            switch (flourType.ToLower())
            {
                case "white":
                    doughModifier = 1.5;
                    break;
                case "wholegrain":
                    doughModifier = 1.0;
                    break;
            }

            switch (bakingTechnique.ToLower())
            {
                case "crispy":
                    bakingModifier = 0.9;
                    break;
                case "chewy":
                    bakingModifier = 1.1;
                    break;
                case "homemade":
                    bakingModifier = 1.0;
                    break;
            }

            return (2 * Weight * doughModifier * bakingModifier);
        }
    }
}
