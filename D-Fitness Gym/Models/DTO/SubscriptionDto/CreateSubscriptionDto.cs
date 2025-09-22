using D_Fitness_Gym.Models.DTO.MembershipDto;
using D_Fitness_Gym.Models.DTO.TransactionDto;
using D_Fitness_Gym.Models.DTO.UserDto;
using D_Fitness_Gym.Models.Enums;

namespace D_Fitness_Gym.Models.DTO.SubscriptionDto
{
    public class CreateSubscriptionDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SubscriptionStatus Status { get; set; } = SubscriptionStatus.Inactive;

        // Navigation Properties
        public CreateUserDto User { get; set; }
        public CreateMembershipDto Membership { get; set; }
        public List<CreateTransactionDto> Transactions { get; set; } = [];
    }
}
