using D_Fitness_Gym.Models.DTO.EnquiryDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Services.Interfaces
{
    public interface IEnquiryService : IBaseService<Enquiry, CreateEnquiryDto, UpdateEnquiryDto, RetrieveEnquiryDto>
    {

    }
}
