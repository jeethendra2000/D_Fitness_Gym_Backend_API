using D_Fitness_Gym.Models.Enums;

namespace D_Fitness_Gym.Models.DTO.EmployeeDto
{
    public class RetrieveEmployeeDto
    {
        public Guid Id { get; set; }
        public string Firebase_UID { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
        public int Salary { get; set; }
        public Status Status { get; set; }
        public Guid? ReportsToEmployeeID { get; set; }
    }
}
