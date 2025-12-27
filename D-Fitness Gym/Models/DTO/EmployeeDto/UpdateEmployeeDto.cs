using D_Fitness_Gym.Models.DTO.AccountDto;
using D_Fitness_Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.DTO.EmployeeDto
{
    public class UpdateEmployeeDto : UpdateAccountDto
    {

        [StringLength(100, ErrorMessage = "Job title cannot exceed 100 characters.")]
        public string? JobTitle { get; set; }

        public DateTime? HireDate { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Salary must be a positive number.")]
        public int? Salary { get; set; }

        public Status Status { get; set; }

        public Guid? ReportsToEmployeeID { get; set; }
    }
}
