using D_Fitness_Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D_Fitness_Gym.Models.Entities
{
    public class Subscription
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public Guid MembershipId { get; set; }

        [Required]
        public DateOnly StartDate { get; set; }

        [Required]
        public DateOnly EndDate { get; set; }

        public SubscriptionStatus Status { get; set; } = SubscriptionStatus.New;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        // Relationship / Navigation Properties
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; } = null!;

        [ForeignKey(nameof(MembershipId))]
        public Membership Membership { get; set; } = null!;
        public ICollection<Transaction> Transactions { get; set; } = [];
    }
}
