using D_Fitness_Gym.Models.DTO.AccountDto;
using D_Fitness_Gym.Models.DTO.SubscriptionDto;
using D_Fitness_Gym.Models.DTO.TrainerDto;

namespace D_Fitness_Gym.Models.DTO.UserDto
{
    public class UpdateUserDto : UpdateAccountDto
    {
        public double Height { get; set; }
        public double Weight { get; set; }
        public bool TrainerRequired { get; set; } = false;

        // Navigation Properties
        public UpdateTrainerDto Trainer { get; set; } = null!;
        public List<UpdateSubscriptionDto> Subscriptions { get; set; }
    }
}
