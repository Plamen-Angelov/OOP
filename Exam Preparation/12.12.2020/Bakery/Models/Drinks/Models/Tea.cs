﻿

namespace Bakery.Models.Drinks.Models
{
    public class Tea : Drink
    {
        private const decimal TeaPrice = 2.50M;
        public Tea(string name, int portion, string brand) 
            : base(name, portion, TeaPrice, brand)
        {
        }
    }
}
