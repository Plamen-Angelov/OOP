using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    class Bus : Vehicle
    {
        private const double AirconditionerConsumption = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public bool IsEmpty { get; set; }

        public override bool CanDrive(double distance)
        {
            if (IsEmpty)
            {
                return distance * FuelConsumption <= FuelQuantity;
            }
            else
            {
                return distance * (FuelConsumption + AirconditionerConsumption) <= FuelQuantity;
            }

        }

        public override void Drive(double distance)
        {
            if (IsEmpty)
            {
                if (CanDrive(distance))
                {
                    FuelQuantity -= distance * FuelConsumption;
                    Console.WriteLine($"Bus travelled { distance} km");
                }
                else
                {
                    Console.WriteLine("Bus needs refueling");
                }
            }
            else if (!IsEmpty)
            {
                if (CanDrive(distance))
                {
                    FuelQuantity -= distance * (FuelConsumption + AirconditionerConsumption);
                    Console.WriteLine($"Bus travelled { distance} km");
                }
                else
                {
                    Console.WriteLine("Bus needs refueling");
                }
            }
        }
    }
}
