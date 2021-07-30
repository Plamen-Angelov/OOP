using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops.Models
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (egg.IsDone() || (bunny.Energy > 0 && bunny.Dyes.Any(d => d.Power > 0)))
            {
                egg.GetColored();
                bunny.Work();
            }
        }
    }
}
