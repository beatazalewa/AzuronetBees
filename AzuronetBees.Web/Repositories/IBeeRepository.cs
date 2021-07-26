using AzuronetBees.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace AzuronetBees.Web.Repositories
{
    public interface IBeeRepository
    {
        IEnumerable<Bee> GetBees();
        Bee GetBeeById(int id);
        void CreateBee(Bee bee);
        void DeleteBee(int id);
        void SaveChanges();
        IQueryable<Beehive> PopulateBeehivesDropDownList();
    }
}

