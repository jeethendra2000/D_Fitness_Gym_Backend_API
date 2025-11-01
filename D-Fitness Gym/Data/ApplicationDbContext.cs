using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace D_Fitness_Gym.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Gym> Gym { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // ---------- Employee ---------- //
            // Optional: Configure discriminator for Employee/Trainer
            modelBuilder.Entity<Employee>()
                .HasDiscriminator<string>("EmployeeType")
                .HasValue<Employee>("Employee")
                .HasValue<Trainer>("Trainer");

            // Unique constraint on Firebase_UID
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Firebase_UID)
                .IsUnique();

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

            // User → Trainer relationship (N:1)
            modelBuilder.Entity<Customer>()
                .HasOne(u => u.Trainer)
                .WithMany(t => t.Customers)
                .HasForeignKey(u => u.TrainerId)
                .OnDelete(DeleteBehavior.NoAction); // prevent multiple cascade paths

            // Transaction → Subscription relationship (N:1)
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Subscription)
                .WithMany(s => s.Transactions)
                .HasForeignKey(t => t.SubscriptionId)
                .OnDelete(DeleteBehavior.SetNull); // if subscription deleted, keep transaction but null SubscriptionId

        }
    }
}
