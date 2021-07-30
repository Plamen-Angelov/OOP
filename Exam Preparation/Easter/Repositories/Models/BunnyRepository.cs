using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private List<IBunny> bunnies = new List<IBunny>();
        public IReadOnlyCollection<IBunny> Models { get; private set; } = new List<IBunny>();

        public void Add(IBunny model)
        {
            bunnies.Add(model);
            Models = bunnies;
        }

        public IBunny FindByName(string name)
        {
            IBunny bunny = bunnies.FirstOrDefault(b => b.Name == name);

            return bunny;
        }

        public bool Remove(IBunny model)
        {
            IBunny bunny = bunnies.FirstOrDefault(b => b == model);

            if (bunny == null)
            {
                return false;
            }

            bunnies.Remove(bunny);
            Models = bunnies;
            return true;
        }
    }
}
