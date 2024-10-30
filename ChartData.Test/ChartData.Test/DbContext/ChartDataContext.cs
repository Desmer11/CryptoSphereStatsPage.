using Microsoft.EntityFrameworkCore;
using ChartData.Test.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CryptoSphereStats.DataContext
{
    public class ChartDataContext : DbContext
    {


        public ChartDataContext(DbContextOptions<ChartDataContext> options) : base(options) { }

        public DbSet<ChartDatas> ChartDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChartDatas>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Month)
                    .IsRequired();

                entity.Property(e => e.Value)
                    .HasColumnType("decimal(18, 2)");

            });

            base.OnModelCreating(modelBuilder);
        }

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
