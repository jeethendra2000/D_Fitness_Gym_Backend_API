using D_Fitness_Gym.Models.DTO.GymDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Services.Interfaces
{
    public interface IGymService : IBaseService<Gym, CreateGymDto, UpdateGymDto, RetrieveGymDto>
    {
        // Extra Business logic layer
    }
}
