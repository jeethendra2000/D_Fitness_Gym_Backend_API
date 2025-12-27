using D_Fitness_Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.Entities
{
    public class Membership
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public required string Description { get; set; }

        [Range(0, 999999)]
        public required decimal Amount { get; set; }
        public required int Duration { get; set; } // Days
        public required MembershipType Type { get; set; }
        public required Status Status { get; set; } = Status.Active;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public List<Subscription> Subscriptions { get; set; } = [];

    }
}
