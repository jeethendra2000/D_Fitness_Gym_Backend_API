using AutoMapper;
using D_Fitness_Gym.Models.DTO.SubscriptionDto;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Models.Enums;
using D_Fitness_Gym.Repositories;
using D_Fitness_Gym.Repositories.Interfaces;
using D_Fitness_Gym.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace D_Fitness_Gym.Services
{
    public class SubscriptionService : BaseService<Subscription, CreateSubscriptionDto, UpdateSubscriptionDto, RetrieveSubscriptionDto>, ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        public SubscriptionService(ISubscriptionRepository subscriptionRepository, IMapper mapper, ILogger<BaseService<Subscription, CreateSubscriptionDto, UpdateSubscriptionDto, RetrieveSubscriptionDto>> logger) : base(subscriptionRepository, mapper, logger)
        {
            _subscriptionRepository = subscriptionRepository;
        }
        
        // Subscription-specific methods can be added here
        public async Task<int> ExpireSubscriptionsAsync()
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            var expiredSubs = await _subscriptionRepository.GetExpiredSubscriptionsAsync(today);
            foreach (var sub in expiredSubs)
            {
                sub.Status = SubscriptionStatus.Expired;
            }

            await _subscriptionRepository.SaveChangesAsync();
            return expiredSubs.Count;
        }
    }
}
