using OnlineShop.Common.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public abstract class Component : Product, IComponent
    {
        public int Generation { get; }


        protected Component(int id, string manufacturer, string model, decimal price, 
            double overallPerformance, int generation) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            Generation = generation;
        }

        public override string ToString()
        {
            return base.ToString(); string.Format(SuccessMessages.ComponentToString, Generation);
        }
    }
}
