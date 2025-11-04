using D_Fitness_Gym.Models.DTO.SubscriptionDto;
using D_Fitness_Gym.Models.Enums;

namespace D_Fitness_Gym.Models.DTO.TransactionDto
{
    public class RetrieveTransactionDto
    {
        public Guid Id { get; set; }

        public Guid PayerId { get; set; }
        public Guid PayeeId { get; set; }

        public decimal Amount { get; set; }

        public TransactionType Type { get; set; }
        public TransactionStatus Status { get; set; }

        public Guid? SubscriptionId { get; set; }

        public string? Description { get; set; }

        public string? PaymentGatewayId { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
