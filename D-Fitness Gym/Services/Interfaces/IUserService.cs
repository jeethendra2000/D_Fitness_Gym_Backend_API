using D_Fitness_Gym.Models.DTO.UserDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Services.Interfaces
{
    public interface IUserService : IBaseService<User, CreateUserDto, UpdateUserDto, RetrieveUserDto>
    {
    }
}
