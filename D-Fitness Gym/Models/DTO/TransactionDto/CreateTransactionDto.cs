using D_Fitness_Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.DTO.TransactionDto
{
    public class CreateTransactionDto
    {
        [Required(ErrorMessage = "PayerId is required.")]
        public Guid PayerId { get; set; }

        [Required(ErrorMessage = "PayeeId is required.")]
        public Guid PayeeId { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(1, 1000000, ErrorMessage = "Amount must be greater than 0.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Transaction type is required.")]
        public TransactionType Type { get; set; }

        [Required(ErrorMessage = "Transaction status is required.")]
        public TransactionStatus Status { get; set; } = TransactionStatus.Pending;

        public Guid? SubscriptionId { get; set; }

        public string? Description { get; set; }

        public string? PaymentGatewayId { get; set; }
    }
}
