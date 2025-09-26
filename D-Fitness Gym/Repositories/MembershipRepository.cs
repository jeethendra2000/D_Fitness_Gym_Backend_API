using D_Fitness_Gym.Data;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Repositories.Interfaces;

namespace D_Fitness_Gym.Repositories
{
    public class MembershipRepository : BaseRepository<Membership>, IMembershipRepository
    {
        public MembershipRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            // Membership-specific methods can be added here
        }
    }
}
