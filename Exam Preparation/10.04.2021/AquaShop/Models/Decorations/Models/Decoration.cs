using AquaShop.Models.Decorations.Contracts;

namespace AquaShop.Models.Decorations.Models
{
    public abstract class Decoration : IDecoration
    {
        public int Comfort { get; }

        public decimal Price { get; }

        protected Decoration(int comfort, decimal price)
        {
            Comfort = comfort;
            Price = price;
        }
    }
}
