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
        public Guid AccountId { get; set; }

        [Required]
        public TransactionType TransactionType { get; set; } = TransactionType.SubscriptionPayment;

        public Guid? SubscriptionId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, 1000000)]
        public decimal Amount { get; set; }

        [Required]
        public PaymentType PaymentType { get; set; } = PaymentType.Cash;

        [StringLength(255)]
        public string? PaymentReferenceId { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public TransactionStatus Status { get; set; } = TransactionStatus.Pending;
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;


        // ---------- Navigation Properties ---------- //

        [ForeignKey(nameof(SubscriptionId))]
        public Subscription? Subscription { get; set; }

        [ForeignKey(nameof(AccountId))]
        public Account Account { get; set; } = null!;
    }
}