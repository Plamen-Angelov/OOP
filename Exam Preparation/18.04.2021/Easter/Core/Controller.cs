using Easter.Core.Contracts;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Bunnies.Models;
using Easter.Repositories.Models;
using Easter.Utilities.Messages;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Dyes.Models;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Eggs.Models;
using Easter.Models.Workshops.Models;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies = new BunnyRepository();
        private EggRepository eggs = new EggRepository();

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;

            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == "SleepyBunny")
            {
                bunny = new SleepyBunny(bunnyName);

            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            bunnies.Add(bunny);
            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = bunnies.FindByName(bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            IDye dye = new Dye(power);

            bunny.AddDye(dye);
            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);

            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            List<IBunny> sortedBunnies = bunnies.Models
                .Where(b => b.Energy >= 50)
                .OrderByDescending(b => b.Energy)
                .ToList();

            if (sortedBunnies == null)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            Workshop workshop = new Workshop();
            IEgg egg = eggs.FindByName(eggName);

            while (sortedBunnies != null)
            {
                IBunny bunny = sortedBunnies.FirstOrDefault(b => b.Dyes.Any(d => d.Power > 0));

                if (bunny == null)
                {
                    break;
                }

                workshop.Color(egg, bunny);

                if (bunny.Energy == 0)
                {
                    bunnies.Remove(bunny);
                    sortedBunnies.Remove(bunny);
                }

                if (egg.IsDone())
                {
                    break;
                }
            }

            if (egg.IsDone())
            {
                return string.Format(OutputMessages.EggIsDone, eggName);
            }
            else
            {
                return string.Format(OutputMessages.EggIsNotDone, eggName);
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            int countDoneEggs = eggs.Models.Where(e => e.IsDone()).Count();

            sb.AppendLine($"{countDoneEggs} eggs are done!");
            sb.AppendLine("Bunnies info:");

            foreach (var bunny in bunnies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Count} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
