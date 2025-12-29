using D_Fitness_Gym.Models.DTO.EmployeeDto;

namespace D_Fitness_Gym.Models.DTO.TrainerDto
{
    public class RetrieveTrainerDto : RetrieveEmployeeDto
    {
        public string Specialization { get; set; } = string.Empty;
        public string? Certification { get; set; }
        public TimeOnly? AvailableFrom { get; set; }
        public TimeOnly? AvailableTo { get; set; }
    }
}
