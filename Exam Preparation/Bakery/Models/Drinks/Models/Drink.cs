﻿using Bakery.Models.Drinks.Contracts;
using System;

namespace Bakery.Models.Drinks.Models
{
    public abstract class Drink : IDrink
    {
        private string name;
        private int portion;
        private decimal price;
        private string brand;

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or white space!");
                }
                name = value;
            }
        }

        public int Portion
        {
            get
            {
                return portion;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Portion cannot be less or equal to zero");
                }
                portion = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to zero!");
                }
                price = value;
            }
        }

        public string Brand
        {
            get
            {
                return brand;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Brand cannot be null or white space!");
                }
                brand = value;
            }
        }

        public Drink(string name, int portion, decimal price, string brand)
        {
            Name = name;
            Portion = portion;
            Price = price;
            Brand = brand;
        }

        public override string ToString()
        {
            return $"{Name} {Brand} - {Portion}ml - {Price:F2}lv";
        }
    }
}
