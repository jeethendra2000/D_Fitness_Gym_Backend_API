using D_Fitness_Gym.Models.DTO.SubscriptionDto;
using D_Fitness_Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.DTO.MembershipDto
{
    public class CreateMembershipDto
    {
        [Required(ErrorMessage = "Membership name is required.")]
        [MaxLength(150, ErrorMessage = "Name cannot exceed 150 characters.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public required string Description { get; set; }

        [Range(1, 100000, ErrorMessage = "Price must be greater than 0.")]
        public required decimal Amount { get; set; }

        [Range(1, 10000, ErrorMessage = "Duration must be greater than 0 days.")]
        public required int Duration { get; set; } // Days

        [Required(ErrorMessage = "Membership type is required.")]
        public required MembershipType Type { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public required Status Status { get; set; }
    }
}
