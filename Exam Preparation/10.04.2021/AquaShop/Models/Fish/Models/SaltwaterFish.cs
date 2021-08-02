using System;

namespace AquaShop.Models.Fish.Models
{
    public class SaltwaterFish : Fish
    {
        private const int initialSize = 5;

        public SaltwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            Size = initialSize;
        }

        public override void Eat()
        {
            Size += 2;
        }
    }
}
