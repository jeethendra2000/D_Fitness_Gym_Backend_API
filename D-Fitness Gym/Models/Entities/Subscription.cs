using D_Fitness_Gym.Models.Enums;

namespace D_Fitness_Gym.Models.Entities
{
    public class Subscription
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SubscriptionStatus Status { get; set; } = SubscriptionStatus.Inactive;

        // Foreign Key
        public Guid UserId { get; set; }
        public Guid MembershipId { get; set; }

        // Relationship / Navigation Properties
        public Customer Customer { get; set; }
        public Membership Membership { get; set; }
        public List<Transaction> Transactions { get; set; } = [];
    }
}
