using System.ComponentModel.DataAnnotations;
using D_Fitness_Gym.Models.Enums;

namespace D_Fitness_Gym.Models.DTO.EnquiryDto
{
    public class UpdateEnquiryDto
    {
        [MaxLength(150, ErrorMessage = "Full name cannot exceed 150 characters.")]
        public string? FullName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [MaxLength(150, ErrorMessage = "Email cannot exceed 150 characters.")]
        public string? Email { get; set; }

        [MaxLength(15, ErrorMessage = "Phone number cannot exceed 15 characters.")]
        public string? PhoneNumber { get; set; }

        [MaxLength(1000, ErrorMessage = "Message cannot exceed 1000 characters.")]
        public string? Message { get; set; }

        public EnquiryStatus? Status { get; set; }
    }
}
