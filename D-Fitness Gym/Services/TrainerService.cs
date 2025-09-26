using AutoMapper;
using D_Fitness_Gym.Models.DTO.TrainerDto;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Repositories.Interfaces;
using D_Fitness_Gym.Services.Interfaces;

namespace D_Fitness_Gym.Services
{
    public class TrainerService : BaseService<Trainer, CreateTrainerDto, UpdateTrainerDto, RetrieveTrainerDto>, ITrainerService
    {
        public TrainerService(ITrainerRepository trainerRepository, IMapper mapper, ILogger<BaseService<Trainer, CreateTrainerDto, UpdateTrainerDto, RetrieveTrainerDto>> logger) : base(trainerRepository, mapper, logger)
        {
            // Trainer-specific methods can be added here

        }
    }
}
