using AutoMapper;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Models.DTO.FeedbackDto;

namespace D_Fitness_Gym.Mappings
{
    public class FeedbackProfile : Profile
    {
        public FeedbackProfile()
        {
            CreateMap<CreateFeedbackDto, Feedback>().ReverseMap();
            CreateMap<UpdateFeedbackDto, Feedback>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Feedback, RetrieveFeedbackDto>().ReverseMap();
        }
    }
}
