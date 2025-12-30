using D_Fitness_Gym.Models.DTO.AccountDto;
using D_Fitness_Gym.Models.Enums;

namespace D_Fitness_Gym.Models.DTO.EmployeeDto
{
    public class RetrieveEmployeeDto : RetrieveAccountDto
    {
        public required string JobTitle { get; set; }
        public int Salary { get; set; }
        public int YearsOfExperience { get; set; }
        public string? Bio { get; set; }
        public DateOnly HireDate { get; set; }
        public Status Status { get; set; }
    }
}
