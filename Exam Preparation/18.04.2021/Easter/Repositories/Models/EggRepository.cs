using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Repositories.Models
{
    public class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> eggs = new List<IEgg>();

        public IReadOnlyCollection<IEgg> Models { get; private set; } 

        public EggRepository()
        {
            Models = new List<IEgg>(eggs);
        }
        public void Add(IEgg model)
        {
            eggs.Add(model);
            Models = eggs;
        }

        public IEgg FindByName(string name)
        {
            return eggs.FirstOrDefault(e => e.Name == name);
        }

        public bool Remove(IEgg model)
        {
            if (eggs.Contains(model))
            {
                eggs.Remove(model);
                Models = eggs;
                return true;
            }
            return false;
        }
    }
}
