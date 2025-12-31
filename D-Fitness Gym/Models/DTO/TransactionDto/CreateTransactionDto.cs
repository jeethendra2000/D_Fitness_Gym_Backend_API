using D_Fitness_Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.DTO.TransactionDto
{
    public class CreateTransactionDto
    {
        [Required(ErrorMessage = "AccountId is required.")]
        public Guid AccountId { get; set; } // The Customer (payer) or Employee (receiver)

        [Required(ErrorMessage = "Transaction type is required.")]
        public TransactionType TransactionType { get; set; }
        public Guid? SubscriptionId { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, 1000000, ErrorMessage = "Amount must be greater than 0.")]
        public decimal Amount { get; set; }

        [Required]
        public PaymentType PaymentType { get; set; } = PaymentType.Cash;
        public string? PaymentReferenceId { get; set; }
        public string? Description { get; set; }

        [Required(ErrorMessage = "Transaction status is required.")]
        public TransactionStatus Status { get; set; } = TransactionStatus.Pending;


    }
}
