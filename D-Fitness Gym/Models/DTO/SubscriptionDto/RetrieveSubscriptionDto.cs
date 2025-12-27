using D_Fitness_Gym.Models.Enums;
using D_Fitness_Gym.Models.DTO.MembershipDto;
using D_Fitness_Gym.Models.DTO.TransactionDto;

namespace D_Fitness_Gym.Models.DTO.SubscriptionDto
{
    public class RetrieveSubscriptionDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid MembershipID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
        public bool AutoRenew { get; set; }

        public RetrieveMembershipDto? Membership { get; set; }
        public List<RetrieveTransactionDto> Transactions { get; set; } = new();
    }
}
