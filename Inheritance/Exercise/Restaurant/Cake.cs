using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double CAKEGRAMS = 250;
        private const double CAKECALORIES = 1000;
        private const decimal CAKEPRICE = 5;


        public Cake(string name)
            : base(name, CAKEPRICE, CAKEGRAMS, CAKECALORIES)
        {

        }
    }
}
