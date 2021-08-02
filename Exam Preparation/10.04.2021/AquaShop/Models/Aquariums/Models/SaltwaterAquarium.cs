using System;

namespace AquaShop.Models.Aquariums.Models
{
    public class SaltwaterAquarium : Aquarium
    {
        private const int initialCapacity = 25;

        public SaltwaterAquarium(string name) 
            : base(name, initialCapacity)
        {
        }
    }
}
