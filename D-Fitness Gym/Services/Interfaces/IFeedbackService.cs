using D_Fitness_Gym.Models.DTO.FeedbackDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Services.Interfaces
{
    public interface IFeedbackService : IBaseService<Feedback, CreateFeedbackDto, UpdateFeedbackDto, RetrieveFeedbackDto>
    {
    }
}
