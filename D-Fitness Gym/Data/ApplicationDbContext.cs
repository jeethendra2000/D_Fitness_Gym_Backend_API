using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace D_Fitness_Gym.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ---------- Role ---------- //

            // Make Role Name unique
            modelBuilder.Entity<Role>()
                .HasIndex(r => r.Name)
                .IsUnique();

            // Seeded Roles – Stable IDs
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Admin" },
                new Role { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Name = "Trainer" },
                new Role { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Name = "User" }
            );


            // ---------- Account ---------- //
            // Make Email unique
            modelBuilder.Entity<Account>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Set Default Role for Account
            modelBuilder.Entity<Account>()
                .Property(a => a.RoleId)
                .HasDefaultValue(Guid.Parse("11111111-1111-1111-1111-111111111111")); // User role ID
            
            // Default values for audit fields
            modelBuilder.Entity<Account>()
                .Property(a => a.CreatedOn)
                .HasDefaultValueSql("GETUTCDATE()");

            // Configure the gender property to be stored as a string
            modelBuilder.Entity<Account>()
                .Property(a => a.Gender)
                .HasConversion(
                    a => a.ToString(),        // Convert enum to string when saving
                    a => Enum.Parse<Gender>(a) // Convert string back to enum when loading
                );

            // ---------- Transaction ---------- //
            modelBuilder.Entity<Transaction>()
                .Property(t => t.CreatedOn)
                .HasDefaultValueSql("GETUTCDATE()");

            // Database Check Constraint
            modelBuilder.Entity<Transaction>()
                .ToTable(t =>
                    t.HasCheckConstraint("CK_Transaction_Subscription",
                        "([Type] = 'SubscriptionPayment' AND [SubscriptionId] IS NOT NULL) OR " +
                        "([Type] <> 'SubscriptionPayment' AND [SubscriptionId] IS NULL)")
                );

            // ---------- Enum Conversion---------- //
            modelBuilder.Entity<Transaction>()
                .Property(t => t.Type)
                .HasConversion<string>();

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Subscription>()
                .Property(s => s.Status)
                .HasConversion<string>();


            // -------------------------
            // Relationships
            // -------------------------
            // Role -> Account relationship (1:N)
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Role)
                .WithMany(r => r.Accounts)
                .HasForeignKey(a => a.RoleId)
                .OnDelete(DeleteBehavior.Restrict); // prevent cascade deletion of accounts if role deleted

            // User → Trainer relationship (N:1)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Trainer)
                .WithMany(t => t.Users)
                .HasForeignKey(u => u.TrainerId)
                .OnDelete(DeleteBehavior.NoAction); // prevent multiple cascade paths

            // Transaction → Payer relationship (N:1)
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Payer)
                .WithMany(a => a.TransactionsAsPayer)
                .HasForeignKey(t => t.PayerId)
                .OnDelete(DeleteBehavior.Restrict); // prevent cascade delete

            // Transaction → Payee relationship (N:1)
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Payee)
                .WithMany(a => a.TransactionsAsPayee)
                .HasForeignKey(t => t.PayeeId)
                .OnDelete(DeleteBehavior.Restrict); // prevent cascade delete

            // Transaction → Subscription relationship (N:1)
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Subscription)
                .WithMany(s => s.Transactions)
                .HasForeignKey(t => t.SubscriptionId)
                .OnDelete(DeleteBehavior.SetNull); // if subscription deleted, keep transaction but null SubscriptionId

        }
    }
}
