using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories.Models
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> cars;
        public IReadOnlyCollection<ICar> Models { get; private set; }

        public CarRepository()
        {
            Models = new List<ICar>();
            cars = new List<ICar>();
        }

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }

            cars.Add(model);
            Models = cars as IReadOnlyList<ICar>;
        }

        public ICar FindBy(string property)
        {
            return cars.FirstOrDefault(c => c.VIN == property);
        }

        public bool Remove(ICar model)
        {
            bool isRemoved = cars.Remove(model);
            Models = cars as IReadOnlyList<ICar>;

            if (isRemoved)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
