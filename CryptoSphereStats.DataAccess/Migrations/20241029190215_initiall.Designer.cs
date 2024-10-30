﻿// <auto-generated />
using CryptoSphereStats.DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CryptoSphereStats.DataAccess.Migrations
{
    [DbContext(typeof(ChartDataContext))]
    [Migration("20241029190215_initiall")]
    partial class initiall
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CryptoSphereStats.Domain.Models.ChartData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CryptocurrencyId")
                        .HasColumnType("int");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("CryptocurrencyId");

                    b.ToTable("ChartData");
                });

            modelBuilder.Entity("CryptoSphereStats.Domain.Models.CryptoData", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CryptocurrencyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("PercentChange24h")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("PriceUsd")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("Rank")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("CryptocurrencyId");

                    b.ToTable("CryptoData");
                });

            modelBuilder.Entity("CryptoSphereStats.Domain.Models.Cryptocurrency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Cryptocurrencies");
                });

            modelBuilder.Entity("CryptoSphereStats.Domain.Models.ChartData", b =>
                {
                    b.HasOne("CryptoSphereStats.Domain.Models.Cryptocurrency", "Cryptocurrency")
                        .WithMany("ChartData")
                        .HasForeignKey("CryptocurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cryptocurrency");
                });

            modelBuilder.Entity("CryptoSphereStats.Domain.Models.CryptoData", b =>
                {
                    b.HasOne("CryptoSphereStats.Domain.Models.Cryptocurrency", "Cryptocurrency")
                        .WithMany("CryptoData")
                        .HasForeignKey("CryptocurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cryptocurrency");
                });

            modelBuilder.Entity("CryptoSphereStats.Domain.Models.Cryptocurrency", b =>
                {
                    b.Navigation("ChartData");

                    b.Navigation("CryptoData");
                });
#pragma warning restore 612, 618
        }
    }
}
