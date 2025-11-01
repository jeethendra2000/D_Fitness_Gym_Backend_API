using AutoMapper;
using D_Fitness_Gym.Models.DTO.GymDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Mappings
{
    public class GymProfile : Profile
    {
        public GymProfile() 
        {
            // DTO → Entity
            CreateMap<CreateGymDto, Gym>().ReverseMap();
            CreateMap<UpdateGymDto, Gym>().ReverseMap();

            // Entity → DTO
            CreateMap<Gym, RetrieveGymDto>().ReverseMap();
        }
    }
}
