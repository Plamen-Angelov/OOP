using EasterRaces.Models.Races.Contracts;
using System.Linq;

namespace EasterRaces.Repositories.Models
{
    public class RaceRepository : Repository<IRace>
    {
        public override IRace GetByName(string name)
        {
            return Models.FirstOrDefault(r => r.Name == name);
        }
    }
}
