using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinPulse.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "Id", "CompanyName", "Industry", "LastDiv", "MarketCap", "Purchase", "Symbol" },
                values: new object[,]
                {
                    { new Guid("3ffa8bdc-9ba8-437f-a061-4e78f7652537"), "Microsoft Corporation", "Technology", 0.56m, 2300000000000L, 305.12m, "MSFT" },
                    { new Guid("55999fc8-8128-452e-9b8a-7c14672d7417"), "Tesla Inc.", "Automotive", 0.00m, 900000000000L, 750.50m, "TSLA" },
                    { new Guid("71cc8c4f-5191-45d9-b769-e37ed28aa390"), "Apple Inc.", "Technology", 0.22m, 2500000000000L, 150.25m, "AAPL" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stock",
                keyColumn: "Id",
                keyValue: new Guid("3ffa8bdc-9ba8-437f-a061-4e78f7652537"));

            migrationBuilder.DeleteData(
                table: "Stock",
                keyColumn: "Id",
                keyValue: new Guid("55999fc8-8128-452e-9b8a-7c14672d7417"));

            migrationBuilder.DeleteData(
                table: "Stock",
                keyColumn: "Id",
                keyValue: new Guid("71cc8c4f-5191-45d9-b769-e37ed28aa390"));
        }
    }
}
