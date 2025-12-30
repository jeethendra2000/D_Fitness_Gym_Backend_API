    using D_Fitness_Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.DTO.AccountDto
{
    public abstract class CreateAccountDto
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(100)]
        public required string Firstname { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(100)]
        public required string Lastname { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public required string Email { get; set; }

        [Required]
        [Phone(ErrorMessage = "Invalid phone number")]
        [StringLength(13)]
        public required string PhoneNumber { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public DateOnly DateOfBirth { get; set; }

        public string? Address { get; set; }
        public string? Description { get; set; }

        public DateOnly JoinedDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public IFormFile? ProfileImageFile { get; set; }

    }
}