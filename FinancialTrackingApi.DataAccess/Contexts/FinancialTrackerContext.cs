﻿using FinancialTrackingApi.DataAccess.Entities;
using FinancialTrackingApi.DataAccess.Helpers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrackingApi.DataAccess.Contexts
{
    public class FinancialTrackerContext : DbContext
    {
        private readonly int _userId;
        private readonly TimeProvider _timeProvider;

        public FinancialTrackerContext(DbContextOptions<FinancialTrackerContext> options, IUserProvider userProvider, TimeProvider timeProvider) : base(options)
        {
            _userId = userProvider.GetUserId();
            _timeProvider = timeProvider;
            SavingChanges += UpdateAuditFields;
        }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();

                entity.ToTable("Users", "dbo");

                entity.HasMany(u => u.Transactions)
                    .WithOne(t => t.User)
                    .HasForeignKey(t => t.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.Property(e => e.TransactionId).IsRequired().ValueGeneratedOnAdd();

                entity.ToTable("Transactions", "dbo");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.HasOne(t => t.User)
                    .WithMany(u => u.Transactions)
                    .HasForeignKey(t => t.UserId);

                entity.HasOne(t => t.Category)
                    .WithMany(c => c.Transactions)
                    .HasForeignKey(t => t.CategoryId);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryId).IsRequired().ValueGeneratedOnAdd();

                entity.ToTable("Categories", "dbo");

                entity.HasMany(c => c.Transactions)
                    .WithOne(t => t.Category)
                    .HasForeignKey(t => t.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasData(
                    new Category { CategoryId = 1, Name = "Housing", Description = "Rent, mortgage, property taxes, repairs" },
                    new Category { CategoryId = 2, Name = "Utilities", Description = "Electricity, water, gas, internet" },
                    new Category { CategoryId = 3, Name = "Groceries", Description = "Food, household supplies" },
                    new Category { CategoryId = 4, Name = "Transportation", Description = "Fuel, public transit, parking fees, vehicle maintenance" },
                    new Category { CategoryId = 5, Name = "Dining Out", Description = "Restaurants, coffee shops" },
                    new Category { CategoryId = 6, Name = "Entertainment", Description = "Movies, games, events" },
                    new Category { CategoryId = 7, Name = "Healthcare", Description = "Medical appointments, prescriptions, health insurance" },
                    new Category { CategoryId = 8, Name = "Savings & Investments", Description = "Savings account contributions, stocks, bonds" },
                    new Category { CategoryId = 9, Name = "Personal Spending", Description = "Clothes, hobbies, gifts" },
                    new Category { CategoryId = 10, Name = "Income", Description = "Salary, bonuses, other earnings" },
                    new Category { CategoryId = 11, Name = "Other", Description = "Any other expenses" }
                    );
            });
        }

        private void UpdateAuditFields(object? sender, SaveChangesEventArgs? e)
        {
            // TODO: Get user id through http context, please find it in ServiceExtensions.cs
            foreach (var entry in ChangeTracker.Entries().Where(
                (e => (e.State == EntityState.Added || e.State == EntityState.Modified) && e.Entity is Entity && e != default)))
            {
                // If we are adding a new entity, we need to populate CreatedBy and CreatedTime
                if (entry.State == EntityState.Added)
                {
                    ((Entity)entry.Entity).CreatedBy = _userId;
                    ((Entity)entry.Entity).CreatedTime = _timeProvider.GetUtcNow().DateTime;
                }

                // If we are modifiying an existing entity, we need to populate UpdatedBy and UpdatedTime
                if (entry.State == EntityState.Modified)
                {
                    ((Entity)entry.Entity).UpdatedBy = _userId;
                    ((Entity)entry.Entity).UpdatedTime = _timeProvider.GetUtcNow().DateTime;
                }
            }
        }
    }
}