
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CryptoSphereStats.Domain.Models;
using CryptoSphereStats.Domain.Enums;

namespace CryptoSphereStats.DataAccess.DataContext
{
    public class ChartDataContext : DbContext
    {
        public ChartDataContext(DbContextOptions<ChartDataContext> options)
           : base(options)
        {
        }

        public DbSet<Cryptocurrency> Cryptocurrencies { get; set; }
        public DbSet<ChartData> ChartData { get; set; }
        public DbSet<CryptoData> CryptoData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cryptocurrency>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ChartData>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Month).IsRequired();
                entity.Property(e => e.Value).HasColumnType("decimal(18, 2)");

                // Foreign key 
                entity.HasOne(e => e.Cryptocurrency)
                    .WithMany(c => c.ChartData)
                    .HasForeignKey(e => e.CryptocurrencyId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CryptoData>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasMaxLength(10);
                entity.Property(e => e.Rank)
                    .HasColumnType("decimal(18, 2)"); 
                entity.Property(e => e.PriceUsd)
                    .HasColumnType("decimal(18, 2)"); 
                entity.Property(e => e.PercentChange24h)
                    .HasColumnType("decimal(18, 2)"); 

                // Foreign key 
                entity.HasOne(e => e.Cryptocurrency)
                    .WithMany(c => c.CryptoData)
                    .HasForeignKey(e => e.CryptocurrencyId)
                    .OnDelete(DeleteBehavior.Restrict);
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
