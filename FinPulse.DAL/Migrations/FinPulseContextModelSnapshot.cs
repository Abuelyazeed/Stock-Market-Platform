﻿// <auto-generated />
using System;
using FinPulse.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinPulse.DAL.Migrations
{
    [DbContext(typeof(FinPulseContext))]
    partial class FinPulseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FinPulse.DAL.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("StockId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("FinPulse.DAL.Stock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Industry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("LastDiv")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<long>("MarketCap")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Purchase")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stocks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dd9c660f-0307-4abf-9e2a-b33c69e9038f"),
                            CompanyName = "Apple Inc.",
                            Industry = "Technology",
                            LastDiv = 0.22m,
                            MarketCap = 2500000000000L,
                            Purchase = 150.25m,
                            Symbol = "AAPL"
                        },
                        new
                        {
                            Id = new Guid("9898b25c-c7df-4ce2-91c3-c79082635bda"),
                            CompanyName = "Microsoft Corporation",
                            Industry = "Technology",
                            LastDiv = 0.56m,
                            MarketCap = 2300000000000L,
                            Purchase = 305.12m,
                            Symbol = "MSFT"
                        },
                        new
                        {
                            Id = new Guid("f8733bac-1c46-4e8e-923c-7caf15a25184"),
                            CompanyName = "Tesla Inc.",
                            Industry = "Automotive",
                            LastDiv = 0.00m,
                            MarketCap = 900000000000L,
                            Purchase = 750.50m,
                            Symbol = "TSLA"
                        });
                });

            modelBuilder.Entity("FinPulse.DAL.Comment", b =>
                {
                    b.HasOne("FinPulse.DAL.Stock", "Stock")
                        .WithMany("Comments")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("FinPulse.DAL.Stock", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
