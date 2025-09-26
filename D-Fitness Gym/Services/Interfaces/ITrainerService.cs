using D_Fitness_Gym.Models.DTO.TrainerDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Services.Interfaces
{
    public interface ITrainerService : IBaseService<Trainer, CreateTrainerDto, UpdateTrainerDto, RetrieveTrainerDto>
    {
        // Trainer-specific methods can be added here

    }
}
