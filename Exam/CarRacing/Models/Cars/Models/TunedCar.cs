﻿using System;

namespace CarRacing.Models.Cars.Models
{
    public class TunedCar : Car
    {
        public TunedCar(string make, string model, string VIN, int horsePower) 
            : base(make, model, VIN, horsePower, 65, 7.5)
        {
        }

        public override void Drive()
        {
            base.Drive();

            HorsePower -= (int)Math.Round((double)HorsePower * 3 / 100);
        }
    }
}
