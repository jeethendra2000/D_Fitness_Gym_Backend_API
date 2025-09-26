using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.DTO.AccountDto
{
    public class CreateAccountDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "Minimum length should be 1")]
        [MaxLength(50, ErrorMessage = "Maximum length should be 50")]
        public required string Firstname { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Minimum length should be 1")]
        [MaxLength(50, ErrorMessage = "Maximum length should be 50")]
        public required string Lastname { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Minimum length should be 1")]
        [MaxLength(50, ErrorMessage = "Maximum length should be 50")]
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
