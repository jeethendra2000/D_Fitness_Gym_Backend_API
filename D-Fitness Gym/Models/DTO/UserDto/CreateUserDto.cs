using D_Fitness_Gym.Models.DTO.AccountDto;
using D_Fitness_Gym.Models.DTO.SubscriptionDto;
using D_Fitness_Gym.Models.DTO.TrainerDto;

namespace D_Fitness_Gym.Models.DTO.UserDto
{
    public class CreateUserDto : CreateAccountDto
    {
        public double Height { get; set; }
        public double Weight { get; set; }
        public bool TrainerRequired { get; set; } = false;

        // Navigation Properties
        public CreateTrainerDto Trainer { get; set; } = null!;
        public List<CreateSubscriptionDto> Subscriptions { get; set; }
    }
}
