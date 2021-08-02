using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace AquaShop.Repositories.Models
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> decorations = new List<IDecoration>();

        public IReadOnlyCollection<IDecoration> Models { get; private set; }

        public DecorationRepository()
        {
            Models = new List<IDecoration>();
        }

        public void Add(IDecoration model)
        {
            decorations.Add(model);
            Models = decorations;
        }

        public IDecoration FindByType(string type)
        {
            return decorations.FirstOrDefault(d => d.GetType().Name == type);
        }

        public bool Remove(IDecoration model)
        {
            if (decorations.Contains(model))
            {
                decorations.Remove(model);
                Models = decorations;
                return true;
            }
            return false;
        }
    }
}
