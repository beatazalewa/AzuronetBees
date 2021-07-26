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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beehive>().HasData(
            new Beehive
            {
                BeehiveId = 1,
                BeehiveName = "A",
                Description = "Ul niebieski pod czereśnią",
                Location = "Pierwszy z prawej strony"
            },
            new Beehive
            {
                BeehiveId = 2,
                BeehiveName = "B",
                Description = "Ul żółty pod czereśnią",
                Location = "Drugi z prawej strony"
            },
            new Beehive
            {
                BeehiveId = 3,
                BeehiveName = "C",
                Description = "Ul ze styroduru",
                Location = "Pierwszy z lewej strony"
            },
            new Beehive
            {
                BeehiveId = 4,
                BeehiveName = "D",
                Description = "Ul ze styroduru",
                Location = "Drugi z lewej strony"
            },
            new Beehive
            {
                BeehiveId = 5,
                BeehiveName = "E",
                Description = "Ul ze styroduru",
                Location = "Pierwszy z lewej strony w drugim rzędzie"
            },
            new Beehive
            {
                BeehiveId = 6,
                BeehiveName = "F",
                Description = "Ul ze styroduru",
                Location = "Drugi z lewej strony w drugim rzędzie"
            },
            new Beehive
            {
                BeehiveId = 7,
                BeehiveName = "G",
                Description = "Ulik weselny",
                Location = "Na środu pasieki"
            }
        );
            modelBuilder.Entity<Bee>().HasData(
            new Bee
            {
                BeeId = 1,
                BreedOfBees = BreedOfBees.Hinderhofer,
                Description = "Hinderhofer od Darka",
                SwarmingBees = false,
                Active = true,
                Overall = 9,
                BeehiveId = 1,
                ImageMimeType = "image/jpeg",
                ImageName = "hinderhofer.jpg"
            },
            new Bee
            {
                BeeId = 2,
                BreedOfBees = BreedOfBees.Alpejka,
                Description = "Alpejka od Mateusza",
                SwarmingBees = false,
                Active = true,
                Overall = 9,
                BeehiveId = 2,
                ImageMimeType = "image/jpeg",
                ImageName = "alpejka.jpg"
            },
            new Bee
            {
                BeeId = 3,
                BreedOfBees = BreedOfBees.Celle,
                Description = "Celle z Niemiec",
                SwarmingBees = true,
                Active = true,
                Overall = 8,
                BeehiveId = 3,
                ImageMimeType = "image/jpeg",
                ImageName = "celle.jpg"
            },
           new Bee
           {
               BeeId = 4,
               BreedOfBees = BreedOfBees.Karpatka,
               Description = "Karpatka z Barci",
               SwarmingBees = false,
               Active = true,
               Overall = 7,
               BeehiveId = 4,
               ImageMimeType = "image/jpeg",
               ImageName = "karpatka.jpg"
           });
        }
    }
}

