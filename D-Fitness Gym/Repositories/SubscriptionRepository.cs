using D_Fitness_Gym.Data;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Models.Enums;
using D_Fitness_Gym.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace D_Fitness_Gym.Repositories
{
    public class SubscriptionRepository : BaseRepository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }

        // Subscription-specific methods can be added here
        public async Task<List<Subscription>> GetExpiredSubscriptionsAsync(DateOnly today)
        {
            return await _dbContext.Subscriptions.Where(s =>
            (s.Status == SubscriptionStatus.Active || s.Status == SubscriptionStatus.New) &&
            s.EndDate < today).ToListAsync();
        }
    }
}
