namespace D_Fitness_Gym.Models.Enums
{
    public enum TransactionStatus
    {
        Pending, // Payment initiated but not completed
        Completed,  // Payment done successfully
        Failed,     // Payment failed
        Cancelled,
        Refunded
    }
}
