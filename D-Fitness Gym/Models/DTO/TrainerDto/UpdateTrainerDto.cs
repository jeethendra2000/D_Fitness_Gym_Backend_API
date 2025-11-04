using D_Fitness_Gym.Models.DTO.EmployeeDto;
using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.DTO.TrainerDto
{
    public class UpdateTrainerDto : UpdateEmployeeDto
    {
        [StringLength(100, ErrorMessage = "Specialization cannot exceed 100 characters.")]
        public string? Specialization { get; set; }

        [Range(0, 60, ErrorMessage = "Experience must be between 0 and 60 years.")]
        public int? YearsOfExperience { get; set; }

        [StringLength(500, ErrorMessage = "Bio cannot exceed 500 characters.")]
        public string? Bio { get; set; }

        [StringLength(150, ErrorMessage = "Certification cannot exceed 150 characters.")]
        public string? Certification { get; set; }

        [Range(0.0, 5.0, ErrorMessage = "Rating must be between 0.0 and 5.0.")]
        public decimal? Rating { get; set; }

        public TimeOnly? AvailableFrom { get; set; }

        public TimeOnly? AvailableTo { get; set; }
    }
}
