using System.ComponentModel.DataAnnotations;
using D_Fitness_Gym.Models.Enums;

namespace D_Fitness_Gym.Models.DTO.SubscriptionDto
{
    public class UpdateSubscriptionDto
    {
        public Guid? CustomerId { get; set; }

        public Guid? MembershipID { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Status? Status { get; set; }

        public bool? AutoRenew { get; set; }

    }
}
