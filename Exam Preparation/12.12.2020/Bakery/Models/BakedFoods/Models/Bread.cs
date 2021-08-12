using System;

namespace Bakery.Models.BakedFoods.Models
{
    public class Bread : BakedFood
    {
        public Bread(string name, decimal price) 
            : base(name, 200, price)
        {
        }
    }
}
