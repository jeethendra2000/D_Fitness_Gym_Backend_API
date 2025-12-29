using D_Fitness_Gym.Models.DTO.AccountDto;
using D_Fitness_Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.DTO.EmployeeDto
{
    public class CreateEmployeeDto : CreateAccountDto
    {

        [Required(ErrorMessage = "Job title is required.")]
        [StringLength(100, ErrorMessage = "Job title cannot exceed 100 characters.")]
        public required string JobTitle { get; set; }

        [Required(ErrorMessage = "Hire date is required.")]
        public DateOnly HireDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Required(ErrorMessage = "Salary is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Salary must be a positive number.")]
        public int Salary { get; set; }

        [Required(ErrorMessage = "Experience is required.")]
        [Range(0, 60, ErrorMessage = "Experience must be between 0 and 60 years")]
        public int YearsOfExperience { get; set; } = 0;

        [StringLength(300, ErrorMessage = "Bio cannot exceed 300 characters.")]
        public string? Bio { get; set; }

        public Status Status { get; set; } = Status.Active;

    }
}
