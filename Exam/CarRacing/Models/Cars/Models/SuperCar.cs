﻿using System;

namespace CarRacing.Models.Cars.Models
{
    public class SuperCar : Car
    {
        public SuperCar(string make, string model, string VIN, int horsePower) 
            : base(make, model, VIN, horsePower, 80, 10)
        {
        }
    }
}
