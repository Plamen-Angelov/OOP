using System;

namespace EasterRaces.Models.Cars.Models
{
    public class SportsCar : Car
    {
        private const int initialCubicCentimeters = 3000;
        private const int minHorsePower = 250;
        private const int maxHorsePower = 450;

        public SportsCar(string model, int horsePower) 
            : base(model, horsePower, initialCubicCentimeters, minHorsePower, maxHorsePower)
        {
        }
    }
}
