using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.DTO.SubscriptionDto
{
    public class CreateSubscriptionDto
    {
        [Required(ErrorMessage = "CustomerId is required.")]
        public Guid CustomerId { get; set; }

        [Required(ErrorMessage = "MembershipId is required.")]
        public Guid MembershipId { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        public DateOnly StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        public DateOnly EndDate { get; set; }

        [Required]
        public SubscriptionStatus Status { get; set; } = SubscriptionStatus.New;

    }
}
