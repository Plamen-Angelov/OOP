using System;

namespace AquaShop.Models.Fish.Models
{
    public class FreshwaterFish : Fish
    {
        private const int initialSize = 3;

        public FreshwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            Size = initialSize;
        }

        public override void Eat()
        {
            Size += 3;
        }
    }
}
