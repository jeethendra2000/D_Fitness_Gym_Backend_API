using D_Fitness_Gym.Data;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Repositories.Interfaces;

namespace D_Fitness_Gym.Repositories
{
    // Data access layer
    public class GymRepository : BaseRepository<Gym>, IGymRepository
    {
        // Gym-specific methods can be added here
        public GymRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
