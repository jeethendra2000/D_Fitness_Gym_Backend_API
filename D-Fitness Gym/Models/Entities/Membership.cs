namespace D_Fitness_Gym.Models.Entities
{
    public class Membership
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required int Amount { get; set; }
        public required int Duration { get; set; } // months
        public string? Description { get; set; }

        // Relationship / Navigation Properties
        public List<Subscription>? Subscriptions { get; set; }

    }
}
