
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using System.Linq;

namespace Easter.Models.Bunnies.Models
{
    public class HappyBunny : Bunny
    {
        private const int initialEnergy = 100;

        public HappyBunny(string name) 
            : base(name, initialEnergy)
        {
        }

        public override void Work()
        {
            Energy -= 10;

            IDye currentDye = Dyes.FirstOrDefault(d => d.Power > 0);
            currentDye.Use();
        }
    }
}
