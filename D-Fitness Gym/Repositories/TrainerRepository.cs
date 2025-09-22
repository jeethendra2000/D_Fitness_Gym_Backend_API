using D_Fitness_Gym.Data;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Repositories.Interfaces;

namespace D_Fitness_Gym.Repositories
{
    public class TrainerRepository : BaseRepository<Trainer>, ITrainerRepository
    {
        public TrainerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            // Trainer-specific methods can be added here

        }
    }
}
