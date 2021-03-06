using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Drivers.Models
{
    public class Driver : IDriver
    {
        private string name;
        private bool canParticipate;

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
        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; } = 0;

        public bool CanParticipate
        {
            get
            {
                return canParticipate;
            }
            private set
            {
                if (Car == null)
                {
                    canParticipate = false;
                }
                else
                {
                    canParticipate = true;
                }
            }
        }

        public Driver(string name)
        {
            Name = name;
        }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarInvalid);
            }
            Car = car;
            CanParticipate = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
    }
}
