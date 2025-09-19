using AutoMapper;
using D_Fitness_Gym.Models.DTO.RoleDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            // DTO → Entity
            CreateMap<CreateRoleDto, Role>().ReverseMap();
            CreateMap<UpdateRoleDto, Role>().ReverseMap();

            // Entity → DTO
            CreateMap<Role, RetrieveRoleDto>().ReverseMap();
        }
    }
}
