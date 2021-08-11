using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Dyes.Models
{
    public class Dye : IDye
    {
        public int Power { get; private set; }

        public Dye(int power)
        {
            Power = power;
        }

        public bool IsFinished()
        {
            if (Power == 0)
            {
                return true;
            }
            return false;
        }

        public void Use()
        {
            Power -= 10;

            if (Power < 0)
            {
                Power = 0;
            }
        }
    }
}
