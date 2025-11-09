using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.DTO.CustomerDto
{
    public class CreateCustomerDto
    {
        [Required(ErrorMessage = "Firebase UID is required.")]
        [StringLength(100, ErrorMessage = "Firebase UID cannot exceed 100 characters.")]
        public required string Firebase_UID { get; set; }

        [Range(0, 300, ErrorMessage = "Height must be between 0 and 300 cm.")]
        public double Height { get; set; }

        [Range(0, 300, ErrorMessage = "Weight must be between 0 and 300 kg.")]
        public double Weight { get; set; }

        public bool TrainerRequired { get; set; } = false;

        public Guid? TrainerId { get; set; }
    }
}
