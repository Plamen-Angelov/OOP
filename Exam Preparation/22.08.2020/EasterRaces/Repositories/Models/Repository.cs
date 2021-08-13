using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;

namespace EasterRaces.Repositories.Models
{
    public abstract class Repository<T> : IRepository<T>
    {
        public ICollection<T> Models { get; }
        public Repository()
        {
            Models = new List<T>();
        }

        public void Add(T model)
        {
            Models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return Models as IReadOnlyCollection<T>;
        }

        public abstract T GetByName(string name);

        public bool Remove(T model)
        {
            if (Models.Contains(model))
            {
                Models.Remove(model);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
