
namespace WarCroft.Entities.Inventory.Models
{
    public class Backpack : Bag
    {
        private const int initialCapacity = 100;
        public Backpack() 
            : base(initialCapacity)
        {
        }
    }
}
