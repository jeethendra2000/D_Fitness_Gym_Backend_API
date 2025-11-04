using D_Fitness_Gym.Models.DTO.SubscriptionDto;
using D_Fitness_Gym.Models.Enums;

namespace D_Fitness_Gym.Models.DTO.MembershipDto
{
    public class RetrieveMembershipDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Amount { get; set; }
        public int Duration { get; set; } // Days
        public MembershipType Type { get; set; }
        public Status Status { get; set; }
    }
}
