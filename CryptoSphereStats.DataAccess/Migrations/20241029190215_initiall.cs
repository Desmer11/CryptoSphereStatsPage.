﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoSphereStats.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initiall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cryptocurrencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cryptocurrencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChartData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CryptocurrencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChartData_Cryptocurrencies_CryptocurrencyId",
                        column: x => x.CryptocurrencyId,
                        principalTable: "Cryptocurrencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CryptoData",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Rank = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceUsd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PercentChange24h = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CryptocurrencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CryptoData_Cryptocurrencies_CryptocurrencyId",
                        column: x => x.CryptocurrencyId,
                        principalTable: "Cryptocurrencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChartData_CryptocurrencyId",
                table: "ChartData",
                column: "CryptocurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CryptoData_CryptocurrencyId",
                table: "CryptoData",
                column: "CryptocurrencyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChartData");

            migrationBuilder.DropTable(
                name: "CryptoData");

            migrationBuilder.DropTable(
                name: "Cryptocurrencies");
        }
    }
}