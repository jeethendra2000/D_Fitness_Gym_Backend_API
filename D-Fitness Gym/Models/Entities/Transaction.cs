using D_Fitness_Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D_Fitness_Gym.Models.Entities
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid PayerId { get; set; }   // Reference to Account ID (Customer/Employee)

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, 1000000)]
        public decimal Amount { get; set; }

        [Required]
        public PaymentType PaymentType { get; set; } = PaymentType.Cash;

        [Required]
        public TransactionStatus Status { get; set; } = TransactionStatus.Pending;

        [StringLength(500)]
        public string? Description { get; set; }

        [StringLength(255)]
        public string? PaymentGatewayId { get; set; }  // Stripe/Razorpay/PayPal ID

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        // ---------- Foreign Keys ---------- //

        public Guid? SubscriptionId { get; set; }

        public Guid? OfferId { get; set; }

        // ---------- Navigation Properties ---------- //

        [ForeignKey(nameof(SubscriptionId))]
        public Subscription? Subscription { get; set; }

        [ForeignKey(nameof(OfferId))]
        public Offer? AppliedDiscount { get; set; }
    }
}