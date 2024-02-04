﻿// <auto-generated />
using System;
using FinancialTrackingApi.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinancialTrackingApi.DataAccess.Migrations
{
    [DbContext(typeof(FinancialTrackerContext))]
    [Migration("20240204074401_AddDefaultValueForCategory")]
    partial class AddDefaultValueForCategory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FinancialTrackingApi.DataAccess.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories", "dbo");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Description = "Rent, mortgage, property taxes, repairs",
                            Name = "Housing"
                        },
                        new
                        {
                            CategoryId = 2,
                            Description = "Electricity, water, gas, internet",
                            Name = "Utilities"
                        },
                        new
                        {
                            CategoryId = 3,
                            Description = "Food, household supplies",
                            Name = "Groceries"
                        },
                        new
                        {
                            CategoryId = 4,
                            Description = "Fuel, public transit, parking fees, vehicle maintenance",
                            Name = "Transportation"
                        },
                        new
                        {
                            CategoryId = 5,
                            Description = "Restaurants, coffee shops",
                            Name = "Dining Out"
                        },
                        new
                        {
                            CategoryId = 6,
                            Description = "Movies, games, events",
                            Name = "Entertainment"
                        },
                        new
                        {
                            CategoryId = 7,
                            Description = "Medical appointments, prescriptions, health insurance",
                            Name = "Healthcare"
                        },
                        new
                        {
                            CategoryId = 8,
                            Description = "Savings account contributions, stocks, bonds",
                            Name = "Savings & Investments"
                        },
                        new
                        {
                            CategoryId = 9,
                            Description = "Clothes, hobbies, gifts",
                            Name = "Personal Spending"
                        },
                        new
                        {
                            CategoryId = 10,
                            Description = "Salary, bonuses, other earnings",
                            Name = "Income"
                        },
                        new
                        {
                            CategoryId = 11,
                            Description = "Any other expenses",
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("FinancialTrackingApi.DataAccess.Entities.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TransactionId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions", "dbo");
                });

            modelBuilder.Entity("FinancialTrackingApi.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users", "dbo");
                });

            modelBuilder.Entity("FinancialTrackingApi.DataAccess.Entities.Transaction", b =>
                {
                    b.HasOne("FinancialTrackingApi.DataAccess.Entities.Category", "Category")
                        .WithMany("Transactions")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinancialTrackingApi.DataAccess.Entities.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FinancialTrackingApi.DataAccess.Entities.Category", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("FinancialTrackingApi.DataAccess.Entities.User", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}