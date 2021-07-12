using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {

        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {

        }

        public override void Drive(double distance)
        {
            if (CanDrive(distance))
            {
                FuelQuantity -= distance * (FuelConsumption + 1.6);
            }
        }

        public override void Refuel(double quantity)
        {
            FuelQuantity += quantity * 0.95;
        }

        public bool CanDrive(double distance)
        {
            return distance * (FuelConsumption + 1.6) <= FuelQuantity;

        }
    }
}
