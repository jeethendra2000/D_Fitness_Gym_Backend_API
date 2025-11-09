using AutoMapper;
using D_Fitness_Gym.Models.DTO.CustomerDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            // Create DTO → Entity
            CreateMap<CreateCustomerDto, Customer>().ReverseMap();

            // Update DTO → Entity
            // Null values do NOT overwrite existing database fields
            CreateMap<UpdateCustomerDto, Customer>().ForAllMembers(opt => opt.Condition((src, dest, srcValue) => srcValue != null));

            // Entity → Retrieve DTO
            CreateMap<Customer, RetrieveCustomerDto>().ReverseMap();
        }
    }
}
