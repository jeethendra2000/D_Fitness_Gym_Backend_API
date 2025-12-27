using D_Fitness_Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public required Guid PayerId { get; set; }   // who pays - owner, customer

        [Range(1, 1000000)]
        public required decimal Amount { get; set; }
        public required PaymentType PaymentType { get; set; } = PaymentType.Cash;
        public string? Description { get; set; }
        public string? PaymentGatewayId { get; set; }  // Stripe/Razorpay ID
        public Guid? SubscriptionId { get; set; } 
        public Guid? OfferId { get; set; }

        [MaxLength(255)]
        public required TransactionStatus Status { get; set; } = TransactionStatus.Pending;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        // Relationship / Navigation Properties
        public Subscription? Subscription { get; set; }
        public Offer? AppliedDiscount { get; set; }
    }
}
