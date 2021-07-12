using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
       //private double fuelQuantity;
       //private double fuelConsumption;

        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }


        public abstract void Drive(double distance);

        public abstract void Refuel(double quantity);
    }
}
