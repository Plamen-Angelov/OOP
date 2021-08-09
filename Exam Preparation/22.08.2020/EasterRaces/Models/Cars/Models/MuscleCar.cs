using System;

namespace EasterRaces.Models.Cars.Models
{
    public class MuscleCar : Car
    {
        private const double initialCubicCentimeters = 5000;
        private const int minHorsePower = 400;
        private const int maxHorsePower = 600;

        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower, initialCubicCentimeters, minHorsePower, maxHorsePower)
        {
        }
    }
}
