using AzuronetBees.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace AzuronetBees.Web.Data
{
    public class BeeContext : DbContext
    {
        public BeeContext(DbContextOptions<BeeContext> options) : base(options)
        {
        }

        public DbSet<Bee> Bees { get; set; }
        public DbSet<Beehive> Beehives { get; set; }
    }
}

