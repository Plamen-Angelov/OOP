using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const decimal COFFEEPRICE = 3.50m;
        private const double COFFEMILLITERS = 50;
        public double Caffeine { get; set; }

        public Coffee(string name, double caffeine)
            :base(name, COFFEEPRICE, COFFEMILLITERS)
        {
            Caffeine = caffeine;
        }
    }
}
