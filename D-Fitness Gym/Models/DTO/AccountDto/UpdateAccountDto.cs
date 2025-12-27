using D_Fitness_Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.DTO.AccountDto
{
    public class UpdateAccountDto
    {
        [Required(ErrorMessage = "Account ID is required.")]
        public Guid Id { get; set; }

        [StringLength(100, ErrorMessage = "First name must not exceed 100 characters.")]
        public string? Firstname { get; set; }

        [StringLength(100, ErrorMessage = "Last name must not exceed 100 characters.")]
        public string? Lastname { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string? Email { get; set; }

        public Gender? Gender { get; set; }

        public DateOnly? DateOfBirth { get; set; }

        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string? PhoneNumber { get; set; }

        [StringLength(250, ErrorMessage = "Address must not exceed 250 characters.")]
        public string? Address { get; set; }

        [StringLength(500, ErrorMessage = "Description must not exceed 500 characters.")]
        public string? Description { get; set; }

        public DateOnly? JoinedDate { get; set; }
    }
}
