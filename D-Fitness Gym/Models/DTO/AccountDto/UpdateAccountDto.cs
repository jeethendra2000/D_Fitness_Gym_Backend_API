using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.DTO.AccountDto
{
    public class UpdateAccountDto
    {
        [MinLength(1, ErrorMessage = "Minimum length should be 1")]
        [MaxLength(50, ErrorMessage = "Maximum length should be 50")]
        public string Firstname { get; set; }

        [MinLength(1, ErrorMessage = "Minimum length should be 1")]
        [MaxLength(50, ErrorMessage = "Maximum length should be 50")]
        public string Lastname { get; set; }

        [MinLength(1, ErrorMessage = "Minimum length should be 1")]
        [MaxLength(50, ErrorMessage = "Maximum length should be 50")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string? Description { get; set; }
        public DateOnly JoinedDate { get; set; }
    }
}
