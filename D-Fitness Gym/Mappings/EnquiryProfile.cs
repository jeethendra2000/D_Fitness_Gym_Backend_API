using AutoMapper;
using D_Fitness_Gym.Models.DTO.EnquiryDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Mappings
{
    public class EnquiryProfile : Profile
    {
        public EnquiryProfile()
        {
            // Create DTO → Entity
            CreateMap<CreateEnquiryDto, Enquiry>().ReverseMap();

            // Update DTO → Entity
            // Null values will NOT overwrite existing entity fields
            CreateMap<UpdateEnquiryDto, Enquiry>().ForAllMembers(opt => opt.Condition((src, dest, srcValue) => srcValue != null));

            // Entity → Retrieve DTO
            CreateMap<Enquiry, RetrieveEnquiryDto>().ReverseMap();
        }
    }
}
