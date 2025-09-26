using AutoMapper;
using D_Fitness_Gym.Models.DTO.UserDto;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Repositories.Interfaces;
using D_Fitness_Gym.Services.Interfaces;

namespace D_Fitness_Gym.Services
{
    public class UserService : BaseService<User, CreateUserDto, UpdateUserDto, RetrieveUserDto>, IUserService
    {
        public UserService(IUserRepository userRepository, IMapper mapper, ILogger<BaseService<User, CreateUserDto, UpdateUserDto, RetrieveUserDto>> logger) : base(userRepository, mapper, logger)
        {
        }
    }
}
