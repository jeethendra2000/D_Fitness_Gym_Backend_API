using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.DTO.SubscriptionDto
{
    public class CreateSubscriptionDto
    {
        [Required(ErrorMessage = "CustomerId is required.")]
        public Guid CustomerId { get; set; }

        [Required(ErrorMessage = "Membership ID is required.")]
        public Guid MembershipID { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        public DateTime EndDate { get; set; }

        [Required]
        public Status Status { get; set; } = Status.Inactive;
        public bool AutoRenew { get; set; } = false;

    }
}
