using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.DTO.EmployeeDto
{
    public class CreateEmployeeDto
    {
        [Required(ErrorMessage = "Firebase UID is required.")]
        [StringLength(100, ErrorMessage = "Firebase UID cannot exceed 100 characters.")]
        public required string Firebase_UID { get; set; }

        [Required(ErrorMessage = "Job title is required.")]
        [StringLength(100, ErrorMessage = "Job title cannot exceed 100 characters.")]
        public required string JobTitle { get; set; }

        [Required(ErrorMessage = "Hire date is required.")]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Salary must be a positive number.")]
        public int Salary { get; set; }

        public Guid? ReportsToEmployeeID { get; set; }
    }
}
