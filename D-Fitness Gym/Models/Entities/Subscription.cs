using D_Fitness_Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D_Fitness_Gym.Models.Entities
{
    public class Subscription
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(100)]
        public required Guid CustomerId { get; set; } 
        public required Guid MembershipId { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public required bool AutoRenew { get; set; } = false;
        public Status Status { get; set; } = Status.Inactive;

        // Relationship / Navigation Properties
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; } = null!;

        [ForeignKey(nameof(MembershipId))]
        public Membership Membership { get; set; } = null!;
        public List<Transaction> Transactions { get; set; } = [];
    }
}
