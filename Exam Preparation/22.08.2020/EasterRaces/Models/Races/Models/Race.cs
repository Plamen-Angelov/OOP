using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;

namespace EasterRaces.Models.Races.Models
{
    public class Race : IRace
    {
        private string name;
        private int laps;
        private List<IDriver> drivers = new List<IDriver>();

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 5));
                }
                name = value;
            }
        }

        public int Laps
        {
            get
            {
                return laps;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, 1));
                }
                laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers { get; private set; }

        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;
            Drivers = new List<IDriver>();
        }


        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }

            if (driver.CanParticipate == false)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }

            if (drivers.Contains(driver))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverAlreadyAdded, 
                    driver.Name, Name));
            }

            drivers.Add(driver);
            Drivers = drivers;
        }
    }
}
