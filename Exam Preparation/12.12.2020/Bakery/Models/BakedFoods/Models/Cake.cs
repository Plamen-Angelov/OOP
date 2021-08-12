﻿using System;

namespace Bakery.Models.BakedFoods.Models
{
    public class Cake : BakedFood
    {
        public Cake(string name, decimal price) 
            : base(name, 245, price)
        {
        }
    }
}
