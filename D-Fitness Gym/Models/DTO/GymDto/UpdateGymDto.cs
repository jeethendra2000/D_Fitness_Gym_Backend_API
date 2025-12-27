using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.DTO.GymDto
{
    public class UpdateGymDto
    {

        [StringLength(150, MinimumLength = 3, ErrorMessage = "Gym name must be between 3 and 150 characters.")]
        public string? Name { get; set; }

        [StringLength(250, ErrorMessage = "Address cannot exceed 250 characters.")]
        public string? Address { get; set; }

        [StringLength(100, ErrorMessage = "City name cannot exceed 100 characters.")]
        public string? City { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format.")]
        [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 digits.")]
        public string? PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [Url(ErrorMessage = "Invalid website URL format.")]
        public string? Website { get; set; }

        public string? ManagedByFirebaseUID { get; set; }
    }
}
