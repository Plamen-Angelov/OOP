using System;

namespace VehiclesExtension
{
    public class Car : Vehicle
    {
        private const double AirconditionerConsumption = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override void Drive(double distance)
        {
            if (CanDrive(distance))
            {
                FuelQuantity -= distance * (FuelConsumption + AirconditionerConsumption);
                Console.WriteLine($"Car travelled { distance} km");
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }
        }

        //public override void Refuel(double quantity)
        //{
        //    if (quantity <= 0)
        //    {
        //        Console.WriteLine("Fuel must be a positive number");
        //    }
        //    else
        //    {
        //        if (FuelQuantity + quantity > TankCapacity)
        //        {
        //            Console.WriteLine($"Cannot fit {quantity} fuel in the tank");
        //        }
        //        else
        //        {
        //            FuelQuantity += quantity;
        //        }
        //    }
        //}

        public override bool CanDrive(double distance)
        {
            return distance * (FuelConsumption + AirconditionerConsumption) <= FuelQuantity;
        }
    }
}
