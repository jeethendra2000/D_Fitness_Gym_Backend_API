using D_Fitness_Gym.Models.DTO.AccountDto;
using D_Fitness_Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.DTO.EmployeeDto
{
    public class UpdateEmployeeDto : UpdateAccountDto
    {
        [StringLength(100, ErrorMessage = "Job title cannot exceed 100 characters.")]
        public string? JobTitle { get; set; }

        [Range(0, int.MaxValue)]
        public int? Salary { get; set; }

        [Range(0, 60)]
        public int? YearsOfExperience { get; set; }

        public string? Bio { get; set; }

        public Status? Status { get; set; }

        public DateOnly HireDate { get; set; }
    }
}
