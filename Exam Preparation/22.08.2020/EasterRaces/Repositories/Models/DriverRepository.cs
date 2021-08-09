using EasterRaces.Models.Drivers.Contracts;
using System;
using System.Linq;

namespace EasterRaces.Repositories.Models
{
    public class DriverRepository : Repository<IDriver>
    {
        public override IDriver GetByName(string name)
        {
            return Models.FirstOrDefault(d => d.Name == name);
        }
    }
}
