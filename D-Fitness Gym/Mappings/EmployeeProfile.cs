using AutoMapper;
using D_Fitness_Gym.Models.DTO.EmployeeDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Mappings
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            // Create DTO → Entity
            CreateMap<CreateEmployeeDto, Employee>().ReverseMap();

            // Update DTO → Entity
            // Null values will NOT overwrite existing entity fields
            CreateMap<UpdateEmployeeDto, Employee>().ForAllMembers(opt => opt.Condition((src, dest, srcValue) => srcValue != null));

            // Entity → Retrieve DTO
            CreateMap<Employee, RetrieveEmployeeDto>().ReverseMap();
        }
    }
}
