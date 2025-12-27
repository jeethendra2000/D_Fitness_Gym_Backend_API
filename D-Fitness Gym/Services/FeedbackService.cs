using AutoMapper;
using D_Fitness_Gym.Models.DTO.FeedbackDto;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Repositories.Interfaces;
using D_Fitness_Gym.Services.Interfaces;

namespace D_Fitness_Gym.Services
{
    public class FeedbackService : BaseService<Feedback, CreateFeedbackDto, UpdateFeedbackDto, RetrieveFeedbackDto>, IFeedbackService
    {
        public FeedbackService(IFeedbackRepository feedbackRepository, IMapper mapper, ILogger<BaseService<Feedback, CreateFeedbackDto, UpdateFeedbackDto, RetrieveFeedbackDto>> logger) : base(feedbackRepository, mapper, logger)
        {
        }
    }
}
