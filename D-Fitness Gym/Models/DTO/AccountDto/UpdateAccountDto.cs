using D_Fitness_Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.DTO.AccountDto
{
    public class UpdateAccountDto
    {
        [StringLength(100)]
        public string? Firstname { get; set; }

        [StringLength(100)]
        public string? Lastname { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format")]
        [StringLength(13)]
        public string? PhoneNumber { get; set; }

        public Gender? Gender { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public IFormFile? ProfileImageFile { get; set; }
    }
}
