using D_Fitness_Gym.Models.DTO.SubscriptionDto;
using D_Fitness_Gym.Models.Enums;

namespace D_Fitness_Gym.Models.DTO.TransactionDto
{
    public class CreateTransactionDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Amount { get; set; }
        public TransactionType Type { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public TransactionStatus Status { get; set; } = TransactionStatus.Pending;

        // Navigation Properties
        public CreateSubscriptionDto Subscription { get; set; }
    }
}
