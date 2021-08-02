using System;

namespace AquaShop.Models.Decorations.Models
{
    public class Ornament : Decoration
    {
        private const int initialComfort = 1;
        private const decimal initialPrice = 5;

        public Ornament() 
            : base(initialComfort, initialPrice)
        {
        }
    }
}
