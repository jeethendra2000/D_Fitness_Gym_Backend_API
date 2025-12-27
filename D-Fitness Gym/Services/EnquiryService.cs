using AutoMapper;
using D_Fitness_Gym.Models.DTO.EnquiryDto;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Repositories.Interfaces;
using D_Fitness_Gym.Services.Interfaces;

namespace D_Fitness_Gym.Services
{
    public class EnquiryService : BaseService<Enquiry, CreateEnquiryDto, UpdateEnquiryDto, RetrieveEnquiryDto>, IEnquiryService
    {
        public EnquiryService(IEnquiryRepository enquiryRepository, IMapper mapper, ILogger<BaseService<Enquiry, CreateEnquiryDto, UpdateEnquiryDto, RetrieveEnquiryDto>> logger) : base(enquiryRepository, mapper, logger)
        {
        }
    }
}
