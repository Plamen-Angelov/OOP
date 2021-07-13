using System;
using System.Collections.Generic;

namespace VehiclesExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            Vehicle bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            int numberOfCommand = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommand; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split();

                string command = tokens[0];
                string vehicle = tokens[1];
                double parameter = double.Parse(tokens[2]);

                try
                {
                    if (command == "Drive")
                    {
                        if (vehicle == "Car")
                        {
                            car.Drive(parameter);
                        }
                        else if (vehicle == "Truck")
                        {
                            truck.Drive(parameter);
                        }
                        else if (vehicle == "Bus")
                        {
                            ((Bus)bus).IsEmpty = false;
                            bus.Drive(parameter);
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        ((Bus)bus).IsEmpty = true;
                        bus.Drive(parameter);
                    }
                    else if (command == "Refuel")
                    {
                        if (vehicle == "Car")
                        {
                            car.Refuel(parameter);
                        }
                        else if (vehicle == "Truck")
                        {
                            //const double quantityTruckCanAdd = 0.95;
                            truck.Refuel(parameter);
                        }
                        else if (vehicle == "Bus")
                        {
                            bus.Refuel(parameter);
                        }
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                
            }
            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}
