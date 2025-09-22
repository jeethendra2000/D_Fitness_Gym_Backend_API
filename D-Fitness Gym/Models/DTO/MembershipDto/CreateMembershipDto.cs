using D_Fitness_Gym.Models.DTO.SubscriptionDto;

namespace D_Fitness_Gym.Models.DTO.MembershipDto
{
    public class CreateMembershipDto
    {
        public required string Name { get; set; }
        public required int Amount { get; set; }
        public required int Duration { get; set; } // months
        public string? Description { get; set; }

        // Navigation Properties
        public List<CreateSubscriptionDto> Subscriptions { get; set; } = [];
    }
}
