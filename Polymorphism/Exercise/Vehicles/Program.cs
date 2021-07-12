using System;

namespace Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carInput = Console.ReadLine()
                .Split();
            Car car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]));

            string[] truckInput = Console.ReadLine()
                .Split();
            Truck truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandLine = Console.ReadLine().Split();
                string command = commandLine[0];
                string vehicle = commandLine[1];
                double parameter = double.Parse(commandLine[2]);

                if (command == "Drive" && vehicle == "Car")
                {
                    if (car.CanDrive(parameter))
                    {
                        car.Drive(parameter);
                        Console.WriteLine($"Car travelled {parameter} km");

                    }
                    else
                    {
                        Console.WriteLine("Car needs refueling");
                    }
                }
                else if (command == "Drive" && vehicle == "Truck")
                {
                    if (truck.CanDrive(parameter))
                    {
                        truck.Drive(parameter);
                        Console.WriteLine($"Truck travelled {parameter} km");
                    }
                    else
                    {
                        Console.WriteLine("Truck needs refueling");
                    }
                }
                else if (command == "Refuel" && vehicle == "Car")
                {
                    car.Refuel(parameter);
                }
                else if (command == "Refuel" && vehicle == "Truck")
                {
                    truck.Refuel(parameter);
                }
            }

            Console.WriteLine($"Car: {Math.Round(car.FuelQuantity,2):F2}");
            Console.WriteLine($"Truck: {Math.Round(truck.FuelQuantity,2):F2}");
        }
    }
}
