using D_Fitness_Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public required Guid PayerId { get; set; }   // who pays - owner, customer
        public required Guid PayeeId { get; set; }  // who receives - owner, employee

        [Range(1, 1000000)]
        public required decimal Amount { get; set; }
        public required TransactionType Type { get; set; }
        public required TransactionStatus Status { get; set; } = TransactionStatus.Pending;
        public Guid? SubscriptionId { get; set; } 
        public string? Description { get; set; }

        [MaxLength(255)]
        public string? PaymentGatewayId { get; set; }  // Stripe/Razorpay ID
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        // Relationship / Navigation Properties
        public Subscription? Subscription { get; set; }
        public Employee? PayeeEmployee { get; set; }
    }
}
