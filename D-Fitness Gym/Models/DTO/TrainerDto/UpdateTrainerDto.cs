using D_Fitness_Gym.Models.DTO.AccountDto;
using D_Fitness_Gym.Models.DTO.UserDto;

namespace D_Fitness_Gym.Models.DTO.TrainerDto
{
    public class UpdateTrainerDto : RetrieveAccountDto
    {
        public int Experience { get; set; }
        public TimeOnly AvailableFrom { get; set; }
        public TimeOnly AvailableTo { get; set; }

        // Navigation Properties
        public List<UpdateUserDto> Users { get; set; } = [];
    }
}
