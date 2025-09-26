using D_Fitness_Gym.Models.DTO.AccountDto;
using D_Fitness_Gym.Models.DTO.TrainerDto;

namespace D_Fitness_Gym.Models.DTO.UserDto
{
    public class RetrieveUserDto : RetrieveAccountDto
    {
        public double Height { get; set; }
        public double Weight { get; set; }
        public bool TrainerRequired { get; set; } = false;

        // Navigation Properties
        public RetrieveTrainerDto Trainer { get; set; } = null!;
    }
}
