using D_Fitness_Gym.Models.Enums;
using D_Fitness_Gym.Models.DTO.MembershipDto;
using D_Fitness_Gym.Models.DTO.TransactionDto;

namespace D_Fitness_Gym.Models.DTO.SubscriptionDto
{
    public class RetrieveSubscriptionDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid MembershipId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public SubscriptionStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public RetrieveMembershipDto? Membership { get; set; }
        public List<RetrieveTransactionDto> Transactions { get; set; } = [];
    }
}
