using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Assecor.EF
{
    public class AssecorDbContextFactory : IDesignTimeDbContextFactory<AssecorDbContext>
    {
        public AssecorDbContext CreateDbContext(string[] args)
        {
            // Build config
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Assecor.API"))
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("Assecor");
            
            var optionsBuilder = new DbContextOptionsBuilder<AssecorDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new AssecorDbContext(optionsBuilder.Options);
        }
    }
}