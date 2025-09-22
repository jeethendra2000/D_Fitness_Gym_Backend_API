using D_Fitness_Gym.Data;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Repositories.Interfaces;

namespace D_Fitness_Gym.Repositories
{
    public class AccountRepository(ApplicationDbContext dbContext) : BaseRepository<Account>(dbContext), IAccountRepository
    {
        // Account-specific methods can be added here

    }
}
