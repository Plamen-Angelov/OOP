using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRacing.Repositories.Models
{
    public class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> racers;
        public IReadOnlyCollection<IRacer> Models { get; private set; }

        public RacerRepository()
        {
            racers = new List<IRacer>();
            Models = new List<IRacer>();
        }

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }

            racers.Add(model);
            Models = racers as IReadOnlyList<IRacer>;
        }

        public IRacer FindBy(string property)
        {
            return racers.FirstOrDefault(r => r.Username == property);
        }

        public bool Remove(IRacer model)
        {
            bool isRemoved = racers.Remove(model);
            Models = racers as IReadOnlyList<IRacer>;

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
