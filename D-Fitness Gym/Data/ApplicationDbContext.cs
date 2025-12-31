using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Models.Enums;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace D_Fitness_Gym.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Offer> Offers { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            // Global enum → string mapping
            builder.Properties<Enum>()
                .HaveConversion<string>()
                .HaveMaxLength(50);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ---------- 1. Inheritance (TPH) ---------- //
            // We configure the discriminator on the ROOT class (Account)
            modelBuilder.Entity<Account>()
                .HasDiscriminator<string>("UserType")
                .HasValue<Account>("BaseAccount") // Should rarely be used
                .HasValue<Customer>("Customer")
                .HasValue<Employee>("Employee")
                .HasValue<Trainer>("Trainer");

            // ---------- 2. Constraints ---------- //
            // Unique constraint on Email for all accounts
            modelBuilder.Entity<Account>()
                .HasIndex(a => a.Email)
                .IsUnique();

            // Precision for Currency fields
            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Membership>()
                .Property(m => m.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Transaction>()
                .Property(t => t.CreatedOn)
                .HasDefaultValueSql("GETUTCDATE()");

            // ---------- 3. Relationships ---------- //

            // Customer → Trainer (Many-to-One)
            modelBuilder.Entity<Customer>()
                .HasOne(u => u.Trainer)
                .WithMany(t => t.Customers)
                .HasForeignKey(u => u.TrainerId)
                .OnDelete(DeleteBehavior.NoAction);

            // Customer → Subscriptions (One-to-Many)
            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.Customer)
                .WithMany(c => c.Subscriptions)
                .HasForeignKey(s => s.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            // Subscription → Transactions (One-to-Many)
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Subscription)
                .WithMany(s => s.Transactions)
                .HasForeignKey(t => t.SubscriptionId)
                .OnDelete(DeleteBehavior.NoAction);

            // Transaction → Account (Many-to-One) -- If an Account is deleted, its transaction history is deleted.
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Account)
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- 4. Data Seeding ---------- //
            modelBuilder.Entity<Membership>().HasData(
                new Membership
                {
                    Id = Guid.Parse("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"),
                    Name = "Monthly Plan",
                    Description = "General Training (G.T.), Morning & Evening Access, Unlimited Equipment, Personal Training, Diet Guidance",
                    Amount = 1200,
                    Duration = 30, // Days
                    Type = MembershipType.Monthly,
                    Status = Status.Active,
                    CreatedOn = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Membership
                {
                    Id = Guid.Parse("b2c3d4e5-f6a7-4b5c-9d0e-1f2a3b4c5d6e"),
                    Name = "3 Months Plan",
                    Description = "General Training (G.T.), 5 Days Personal Training, Diet & Nutrition Guidance, Morning & Evening Access, Unlimited Equipment",
                    Amount = 3000,
                    Duration = 90,
                    Type = MembershipType.Quarterly,
                    Status = Status.Active,
                    CreatedOn = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Membership
                {
                    Id = Guid.Parse("c3d4e5f6-a7b8-4c5d-0e1f-2a3b4c5d6e7f"),
                    Name = "6 Months Plan",
                    Description = "General Training (G.T.), 15 Days Personal Training, Diet & Nutrition Guidance, Morning & Evening Access, Unlimited Equipment",
                    Amount = 5500,
                    Duration = 180,
                    Type = MembershipType.SemiAnnual,
                    Status = Status.Active,
                    CreatedOn = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Membership
                {
                    Id = Guid.Parse("d4e5f6a7-b8c9-4d5e-1f2a-3b4c5d6e7f8a"),
                    Name = "1 Year Plan",
                    Description = "General Training (G.T.), 1 Month Personal Training, Diet & Nutrition Guidance, Morning & Evening Access, Unlimited Equipment",
                    Amount = 9999,
                    Duration = 365,
                    Type = MembershipType.Annual,
                    Status = Status.Active,
                    CreatedOn = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}