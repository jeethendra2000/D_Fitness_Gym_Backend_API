using D_Fitness_Gym.Models.DTO.SubscriptionDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Services.Interfaces
{
    public interface ISubscriptionService : IBaseService<Subscription, CreateSubscriptionDto, UpdateSubscriptionDto, RetrieveSubscriptionDto>
    {
        // Subscription-specific methods can be added here

    }
}
