using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Hero : BaseHero
    {
        public Hero(string type, string name) 
            : base(type, name)
        {
        }

        //public override int Power => base.Power;

        public override string CastAbility()
        {
            if (Type == "Rogue" || Type == "Warrior")
            {
                return $"{Type} – {Name} hit for {Power} damage";
            }
            return base.CastAbility();
        }
    }
}
