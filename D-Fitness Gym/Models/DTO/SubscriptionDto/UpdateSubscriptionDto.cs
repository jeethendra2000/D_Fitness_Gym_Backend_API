using D_Fitness_Gym.Models.DTO.MembershipDto;
using D_Fitness_Gym.Models.DTO.TransactionDto;
using D_Fitness_Gym.Models.Enums;

namespace D_Fitness_Gym.Models.DTO.SubscriptionDto
{
    public class UpdateSubscriptionDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SubscriptionStatus Status { get; set; } = SubscriptionStatus.Inactive;

        // Navigation Properties
        public UpdateMembershipDto Membership { get; set; }
        public List<UpdateTransactionDto> Transactions { get; set; } = [];
    }
}
