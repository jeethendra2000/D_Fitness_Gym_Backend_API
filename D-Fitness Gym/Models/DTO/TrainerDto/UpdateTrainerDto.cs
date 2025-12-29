using D_Fitness_Gym.Models.DTO.EmployeeDto;
using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.DTO.TrainerDto
{
    public class UpdateTrainerDto : UpdateEmployeeDto
    {
        [StringLength(100, ErrorMessage = "Specialization cannot exceed 100 characters.")]
        public string? Specialization { get; set; }

        [StringLength(150, ErrorMessage = "Certification cannot exceed 150 characters.")]
        public string? Certification { get; set; }

        public TimeOnly? AvailableFrom { get; set; }

        public TimeOnly? AvailableTo { get; set; }
    }
}
