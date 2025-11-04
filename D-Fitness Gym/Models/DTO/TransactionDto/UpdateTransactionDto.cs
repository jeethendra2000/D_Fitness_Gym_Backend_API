using D_Fitness_Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.DTO.TransactionDto
{
    public class UpdateTransactionDto
    {
        public Guid? PayerId { get; set; }

        public Guid? PayeeId { get; set; }

        [Range(1, 1000000)]
        public decimal? Amount { get; set; }

        public TransactionType? Type { get; set; }

        public TransactionStatus? Status { get; set; }

        public Guid? SubscriptionId { get; set; }

        public string? Description { get; set; }

        public string? PaymentGatewayId { get; set; }
    }
}
