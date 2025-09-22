using D_Fitness_Gym.Models.DTO.AccountDto;
using D_Fitness_Gym.Models.DTO.UserDto;

namespace D_Fitness_Gym.Models.DTO.TrainerDto
{
    public class CreateTrainerDto : RetrieveAccountDto
    {
        public int Experience { get; set; }
        public TimeOnly AvailableFrom { get; set; }
        public TimeOnly AvailableTo { get; set; }

        // Navigation Properties
        public List<CreateUserDto> Users { get; set; } = [];
    }
}
