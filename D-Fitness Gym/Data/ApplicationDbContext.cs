using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace D_Fitness_Gym.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        //public DbSet<Admin> Admins { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Offer> Offers { get; set; }

        // ---------- Enum Conversion---------- //
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


            // ---------- Employee ---------- //
            // Optional: Configure discriminator for Employee/Trainer
            modelBuilder.Entity<Employee>()
                .HasDiscriminator<string>("EmployeeType")
                .HasValue<Employee>("Employee")
                .HasValue<Trainer>("Trainer");


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
            modelBuilder.Entity<Transaction>()
              .Property(t => t.Amount)
              .HasPrecision(18, 2); // precision, scale

            modelBuilder.Entity<Membership>()
              .Property(m => m.Amount)
              .HasPrecision(18, 2); // precision, scale

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
