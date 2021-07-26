using AzuronetBees.Web.Models;
using AzuronetBees.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AzuronetBees.Tests.FakeRepositories
{
    internal class FakeBeeRepository : IBeeRepository
    {
        public IEnumerable<Bee> GetBees()
        {
            return new List<Bee>()
            {
                new Bee { BeeId = 1, BreedOfBees = BreedOfBees.Hinderhofer, Description = "A description for bee 1.", SwarmingBees = false, Active = true, Overall = 9 },
                new Bee { BeeId = 2, BreedOfBees = BreedOfBees.Alpejka, Description = "A description for bee 2.", SwarmingBees = true, Active = false, Overall = 8 },
                new Bee { BeeId = 3, BreedOfBees = BreedOfBees.Celle, Description = "A description for bee 3.", SwarmingBees = true, Active = true, Overall = 9 },
                new Bee { BeeId = 1, BreedOfBees = BreedOfBees.Gema, Description = "A description for bee 4.", SwarmingBees = false, Active = false, Overall = 6 }
            };
        }

        public void CreateBee(Bee bee)
        {
            throw new NotImplementedException();
        }

        public void DeleteBee(int id)
        {
            throw new NotImplementedException();
        }

        public Bee GetBeeById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Beehive> PopulateBeehivesDropDownList()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
