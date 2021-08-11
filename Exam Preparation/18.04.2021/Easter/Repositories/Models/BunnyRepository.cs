using Easter.Repositories.Contracts;
using Easter.Models.Bunnies.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories.Models
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private List<IBunny> bunnies = new List<IBunny>();

        public IReadOnlyCollection<IBunny> Models { get; private set; } 

        public BunnyRepository()
        {
            Models = new List<IBunny>(bunnies);
        }

        public void Add(IBunny model)
        {
            bunnies.Add(model);
            Models = bunnies;
        }

        public IBunny FindByName(string name)
        {
            return bunnies.FirstOrDefault(b => b.Name == name);
        }

        public bool Remove(IBunny model)
        {
            if (bunnies.Contains(model))
            {
                bunnies.Remove(model);
                Models = bunnies;
                return true;
            }
            return false;
        }
    }
}
