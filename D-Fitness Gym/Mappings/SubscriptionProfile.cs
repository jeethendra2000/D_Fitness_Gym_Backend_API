using AutoMapper;
using D_Fitness_Gym.Models.DTO.SubscriptionDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Mappings
{
    public class SubscriptionProfile : Profile
    {
        public SubscriptionProfile()
        {
            CreateMap<CreateSubscriptionDto, Subscription>().ReverseMap();
            CreateMap<UpdateSubscriptionDto, Subscription>().ReverseMap();
            CreateMap<Subscription, RetrieveSubscriptionDto>().ReverseMap();
        }
    }
}
