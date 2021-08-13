using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Models;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Models;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Models;
using EasterRaces.Repositories.Models;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private CarRepository cars = new CarRepository();
        private DriverRepository drivers = new DriverRepository();
        private RaceRepository races = new RaceRepository();

        public string AddCarToDriver(string driverName, string carModel)
        {
            ICar car = cars.GetByName(carModel);
            IDriver driver = drivers.GetByName(driverName);

            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            driver.AddCar(car);
            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = races.GetByName(raceName);
            IDriver driver = drivers.GetByName(driverName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);
            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = cars.GetByName(model);

            if (car != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            ICar carToAdd = null;

            if (type == "Muscle")
            {
                carToAdd = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                carToAdd = new SportsCar(model, horsePower);
            }

            cars.Add(carToAdd);

            return string.Format(OutputMessages.CarCreated, carToAdd.GetType().Name, model);
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = drivers.GetByName(driverName);

            if (driver != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            IDriver driverToAdd = new Driver(driverName);
            drivers.Add(driverToAdd);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = races.GetByName(name);

            if (race != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace raceToAdd = new Race(name, laps);
            races.Add(raceToAdd);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            IRace race = races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            List<IDriver> champions = drivers.Models
                .Where(d => d.CanParticipate)
                .OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();

            if (champions.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            races.Remove(race);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, champions[0].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, champions[1].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, champions[2].Name, raceName));

            return sb.ToString().TrimEnd();
        }
    }
}
