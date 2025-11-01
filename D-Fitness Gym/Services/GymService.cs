using AutoMapper;
using D_Fitness_Gym.Models.DTO.GymDto;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Repositories.Interfaces;
using D_Fitness_Gym.Services.Interfaces;

namespace D_Fitness_Gym.Services
{
    public class GymService : BaseService<Gym, CreateGymDto, UpdateGymDto, RetrieveGymDto>, IGymService
    {
        public GymService(IGymRepository gymRepository, IMapper mapper, ILogger<BaseService<Gym, CreateGymDto, UpdateGymDto, RetrieveGymDto>> logger) : base(gymRepository, mapper, logger)
        {
            // Gym-specific methods can be added here
        }
    }
}
