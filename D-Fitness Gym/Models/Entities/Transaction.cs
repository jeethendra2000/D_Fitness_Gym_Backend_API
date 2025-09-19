using D_Fitness_Gym.Models.Enums;

namespace D_Fitness_Gym.Models.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Amount { get; set; }
        public TransactionType Type { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public TransactionStatus Status { get; set; } = TransactionStatus.Pending;

        // Foreign Key
        public required Guid PayerId { get; set; }   // who pays
        public required Guid PayeeId { get; set; }  // who receives
        public Guid? SubscriptionId { get; set; }  // Only needed for subscription payments

        // Relationship / Navigation Properties
        public Account Payer { get; set; }
        public Account Payee { get; set; }
        public Subscription Subscription { get; set; }
    }
}
