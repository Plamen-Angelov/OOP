using Easter.Models.Dyes.Contracts;
using System.Linq;

namespace Easter.Models.Bunnies.Models
{
    public class SleepyBunny : Bunny
    {
        private const int initialEnergy = 50;

        public SleepyBunny(string name)
            : base(name, initialEnergy)
        {
        }

        public override void Work()
        {
            Energy -= 15;

            IDye currentDye = Dyes.FirstOrDefault(d => d.Power > 0);
            currentDye.Use();
        }
    }
}
