using D_Fitness_Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.DTO.AccountDto
{
    public class CreateAccountDto
    {

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(100, ErrorMessage = "First name must not exceed 100 characters.")]
        public required string Firstname { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(100, ErrorMessage = "Last name must not exceed 100 characters.")]
        public required string Lastname { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        public DateOnly DateOfBirth { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public required string PhoneNumber { get; set; }

        [StringLength(250, ErrorMessage = "Address must not exceed 250 characters.")]
        public string? Address { get; set; }

        [StringLength(500, ErrorMessage = "Description must not exceed 500 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Joined date is required.")]
        public DateOnly JoinedDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    }
}
