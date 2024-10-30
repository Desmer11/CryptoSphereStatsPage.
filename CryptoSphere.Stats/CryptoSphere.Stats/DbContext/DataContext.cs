using Microsoft.EntityFrameworkCore;
using CryptoSphereStats.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CryptoSphere.Stats.DataContext
{
    public class ChartDataContext : DbContext
    {
        public DbSet<ChartData> ChartDatas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
