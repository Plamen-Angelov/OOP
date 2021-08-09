using EasterRaces.Models.Cars.Contracts;
using System;
using System.Linq;

namespace EasterRaces.Repositories.Models
{
    public class CarRepository : Repository<ICar>
    {
        public override ICar GetByName(string name)
        {
            return Models.FirstOrDefault(c => c.Model == name);
        }
    }
}
