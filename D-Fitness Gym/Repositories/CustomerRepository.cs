using D_Fitness_Gym.Data;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
