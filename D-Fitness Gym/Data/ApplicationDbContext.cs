using D_Fitness_Gym.Models.Entities;
using Microsoft.EntityFrameworkCore;

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

            // Transaction → Subscription (Many-to-One)
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Subscription)
                .WithMany(s => s.Transactions)
                .HasForeignKey(t => t.SubscriptionId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}