using AutoMapper;
using D_Fitness_Gym.Models.DTO.UserDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<RetrieveUserDto, User>().ReverseMap();
        }
    }
}
