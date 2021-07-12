using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override void Drive(double distance)
        {
            if (CanDrive(distance))
            {
                FuelQuantity -= distance * (FuelConsumption + 0.9);
            }
        }

        public override void Refuel(double quantity)
        {
            FuelQuantity += quantity;
        }

        public bool CanDrive(double distance)
        {
            return distance * (FuelConsumption + 0.9) <= FuelQuantity;

        }
    }
}
