using System.Collections.Generic;
using System.Linq;
using System.IO;
using AzuronetBees.Web.Data;
using AzuronetBees.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace AzuronetBees.Web.Repositories
{
    public class BeeRepository : IBeeRepository
    {
        private BeeContext _context;

        public BeeRepository(BeeContext context)
        {
            _context = context;
        }

        public void CreateBee(Bee bee)
        {
            if (bee.PhotoAvatar != null && bee.PhotoAvatar.Length > 0)
            {
                bee.ImageMimeType = bee.PhotoAvatar.ContentType;
                bee.ImageName = Path.GetFileName(bee.PhotoAvatar.FileName);
                using (var memoryStream = new MemoryStream())
                {
                    bee.PhotoAvatar.CopyTo(memoryStream);
                    bee.PhotoFile = memoryStream.ToArray();
                }
                _context.Add(bee);
                _context.SaveChanges();
            }
        }

        public void DeleteBee(int id)
        {
            var bee = _context.Bees.SingleOrDefault(c => c.BeeId == id);
            _context.Bees.Remove(bee);
            _context.SaveChanges();
        }

        public Bee GetBeeById(int id)
        {
            return _context.Bees.Include(b => b.Beehive)
             .SingleOrDefault(c => c.BeeId == id);
        }

        public IEnumerable<Bee> GetBees()
        {
            return _context.Bees.ToList();
        }

        public IQueryable<Beehive> PopulateBeehivesDropDownList()
        {
            var beehivesQuery = from b in _context.Beehives
                                orderby b.BeehiveName
                                select b;
            return beehivesQuery;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

