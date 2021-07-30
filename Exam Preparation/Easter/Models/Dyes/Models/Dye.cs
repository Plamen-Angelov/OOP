using Easter.Models.Dyes.Contracts;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private int power;

        public int Power
        {
            get
            {
                return power;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                power = value;
            }
        }

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
        }
    }
}
