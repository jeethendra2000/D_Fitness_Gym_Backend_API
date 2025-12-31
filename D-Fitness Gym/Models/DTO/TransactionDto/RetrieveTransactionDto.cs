using D_Fitness_Gym.Models.DTO.SubscriptionDto;
using D_Fitness_Gym.Models.Enums;

namespace D_Fitness_Gym.Models.DTO.TransactionDto
{
    public class RetrieveTransactionDto
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public TransactionType TransactionType { get; set; }
        public Guid? SubscriptionId { get; set; }
        public decimal Amount { get; set; }
        public PaymentType PaymentType { get; set; }
        public string? PaymentReferenceId { get; set; }
        public string? Description { get; set; }
        public TransactionStatus Status { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
