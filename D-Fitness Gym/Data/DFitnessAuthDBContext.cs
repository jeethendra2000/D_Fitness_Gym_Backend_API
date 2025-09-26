using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace D_Fitness_Gym.Data
{
    public class DFitnessAuthDBContext : IdentityDbContext
    {
        public DFitnessAuthDBContext(DbContextOptions<DFitnessAuthDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            // Seeded Roles – Stable IDs 
            var adminRoleId = "de4b7405-63f1-4f77-876e-3173fa8d6b86";
            var trainerRoleId = "82f0976e-66d3-4f9b-b657-f2265cd323ce";
            var customerRoleId = "66dc234b-d616-442b-baec-cef239155cf7";
            var guestRoleId = "53f85e82-dda8-4af1-a7ea-d4dbb346e54b";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId, 
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
                new IdentityRole
                {
                    Id = trainerRoleId,
                    ConcurrencyStamp = trainerRoleId,
                    Name = "Trainer",
                    NormalizedName = "Trainer".ToUpper()
                },
                new IdentityRole
                {
                    Id = customerRoleId,
                    ConcurrencyStamp = customerRoleId,
                    Name = "Customer",
                    NormalizedName = "Customer".ToUpper()
                },
                new IdentityRole
                {
                    Id = guestRoleId,
                    ConcurrencyStamp = guestRoleId,
                    Name = "Guest",
                    NormalizedName = "Guest".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
