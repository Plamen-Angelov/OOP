using System;

namespace EasterRaces.Models.Cars.Models
{
    public class MuscleCar : Car
    {
        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower, 5000, 400, 600)
        {
        }
    }
}
