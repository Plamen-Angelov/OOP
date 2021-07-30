using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Repositories.Models
{
    public class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> eggs = new List<IEgg>();
        public IReadOnlyCollection<IEgg> Models { get; private set; } = new List<IEgg>();

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
            IEgg egg = eggs.FirstOrDefault(e => e == model);

            if (egg == null)
            {
                return false;
            }

            eggs.Remove(egg);
            Models = eggs;
            return true;
        }
    }
}
