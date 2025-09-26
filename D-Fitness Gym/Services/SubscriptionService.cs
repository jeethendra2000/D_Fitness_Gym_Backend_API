using AutoMapper;
using D_Fitness_Gym.Models.DTO.SubscriptionDto;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Repositories.Interfaces;
using D_Fitness_Gym.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace D_Fitness_Gym.Services
{
    public class SubscriptionService : BaseService<Subscription, CreateSubscriptionDto, UpdateSubscriptionDto, RetrieveSubscriptionDto>, ISubscriptionService
    {
        public SubscriptionService(ISubscriptionRepository subscriptionRepository, IMapper mapper, ILogger<BaseService<Subscription, CreateSubscriptionDto, UpdateSubscriptionDto, RetrieveSubscriptionDto>> logger) : base(subscriptionRepository, mapper, logger)
        {
            // Subscription-specific methods can be added here

        }
    }
}
