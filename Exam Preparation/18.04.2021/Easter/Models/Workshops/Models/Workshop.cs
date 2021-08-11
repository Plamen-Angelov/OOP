using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Linq;

namespace Easter.Models.Workshops.Models
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (!egg.IsDone())
            {
                if (bunny.Energy <= 0)
                {
                    break;
                }

                IDye dye = bunny.Dyes.FirstOrDefault(d => d.Power > 0);

                if (dye == null)
                {
                    break;
                }

                egg.GetColored();
                bunny.Work();
                dye.Use();

                if (dye.Power <= 0)
                {
                    bunny.Dyes.Remove(dye);
                }
            }
        }
    }
}
