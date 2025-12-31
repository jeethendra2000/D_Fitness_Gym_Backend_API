using D_Fitness_Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.DTO.TransactionDto
{
    public class UpdateTransactionDto
    {
        public Guid? AccountId { get; set; }
        public TransactionType? TransactionType { get; set; }
        public Guid? SubscriptionId { get; set; }

        [Range(0.01, 1000000, ErrorMessage = "Amount must be greater than 0.")]
        public decimal? Amount { get; set; }
        public PaymentType? PaymentType { get; set; }
        public string? PaymentReferenceId { get; set; }
        public string? Description { get; set; }
        public TransactionStatus? Status { get; set; }

    }
}
