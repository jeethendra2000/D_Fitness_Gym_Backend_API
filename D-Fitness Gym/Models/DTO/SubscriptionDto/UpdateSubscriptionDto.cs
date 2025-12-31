using System.ComponentModel.DataAnnotations;
using D_Fitness_Gym.Models.Enums;

namespace D_Fitness_Gym.Models.DTO.SubscriptionDto
{
    public class UpdateSubscriptionDto
    {
        public Guid? CustomerId { get; set; }
        public Guid? MembershipId { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public SubscriptionStatus? Status { get; set; }

    }
}
