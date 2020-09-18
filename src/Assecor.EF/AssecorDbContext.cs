using Assecor.Core.Colors;
using Assecor.Core.Persons;
using Microsoft.EntityFrameworkCore;

namespace Assecor.EF
{
    public class AssecorDbContext : DbContext
    {
        public AssecorDbContext(DbContextOptions<AssecorDbContext> options)
            : base (options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Color> Colors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed default colors
            modelBuilder.Entity<Color>().HasData(
                DefaultColors.Colors
            );
        }
    }
}