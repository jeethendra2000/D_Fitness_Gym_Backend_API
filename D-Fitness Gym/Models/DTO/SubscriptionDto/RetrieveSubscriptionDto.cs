using D_Fitness_Gym.Models.DTO.MembershipDto;
using D_Fitness_Gym.Models.DTO.TransactionDto;
using D_Fitness_Gym.Models.Enums;

namespace D_Fitness_Gym.Models.DTO.SubscriptionDto
{
    public class RetrieveSubscriptionDto
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SubscriptionStatus Status { get; set; } = SubscriptionStatus.Inactive;

        // Navigation Properties
        public RetrieveMembershipDto Membership { get; set; }
        public List<RetrieveTransactionDto> Transactions { get; set; } = [];
    }
}
