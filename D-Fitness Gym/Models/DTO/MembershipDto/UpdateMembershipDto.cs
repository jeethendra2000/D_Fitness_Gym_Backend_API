using D_Fitness_Gym.Models.DTO.SubscriptionDto;
using D_Fitness_Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.DTO.MembershipDto
{
    public class UpdateMembershipDto
    {
        [MaxLength(150, ErrorMessage = "Name cannot exceed 150 characters.")]
        public string Name { get; set; }

        [MaxLength(5000, ErrorMessage = "Description cannot exceed 5000 characters.")]
        public string Description { get; set; }

        [Range(1, 100000, ErrorMessage = "Price must be greater than 0.")]
        public decimal Amount { get; set; }

        [Range(1, 10000, ErrorMessage = "Duration must be greater than 0 days.")]
        public int Duration { get; set; } // Days

        public MembershipType Type { get; set; }

        public Status Status { get; set; }

    }
}
