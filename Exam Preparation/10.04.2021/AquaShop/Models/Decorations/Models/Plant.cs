using System;

namespace AquaShop.Models.Decorations.Models
{
    public class Plant : Decoration
    {
        private const int initialComfort = 5;
        private const decimal initialPrice = 10;

        public Plant()
            : base(initialComfort, initialPrice)
        {
        }
    }
}
