﻿using CarRacing.Models.Cars.Contracts;
using System;

namespace CarRacing.Models.Racers.Models
{
    public class StreetRacer : Racer
    {
        public StreetRacer(string username, ICar car) 
            : base(username, "aggressive", 10, car)
        {
        }

        public override void Race()
        {
            base.Race();
            DrivingExperience += 5;
        }
    }
}
