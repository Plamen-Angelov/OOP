using System;

namespace VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuelQuantity;

        public double TankCapacity { get; set; }

        public double FuelQuantity
        {
            get => fuelQuantity;
            set
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                    Console.WriteLine($"Cannot fit {value} fuel in the tank");
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption { get; set; }

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public abstract void Drive(double distance);

        public virtual void Refuel(double quantity)
        {
            if (quantity <= 0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }
            else
            {
                if (FuelQuantity + quantity > TankCapacity)
                {
                    throw new InvalidOperationException($"Cannot fit {quantity} fuel in the tank");
                }
                else
                {
                    FuelQuantity += quantity;
                }
            }
        }

        public abstract bool CanDrive(double distance);
    }
}
