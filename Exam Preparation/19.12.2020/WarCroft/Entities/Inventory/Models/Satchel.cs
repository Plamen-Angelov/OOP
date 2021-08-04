
namespace WarCroft.Entities.Inventory.Models
{
    public class Satchel : Bag
    {

        private const int initialCapacity = 20;
        public Satchel() 
            : base(initialCapacity)
        {
        }
    }
}
