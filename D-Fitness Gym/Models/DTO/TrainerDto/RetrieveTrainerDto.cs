using D_Fitness_Gym.Models.DTO.CustomerDto;
using D_Fitness_Gym.Models.DTO.EmployeeDto;
using D_Fitness_Gym.Models.DTO.SubscriptionDto;

namespace D_Fitness_Gym.Models.DTO.TrainerDto
{
    public class RetrieveTrainerDto : RetrieveEmployeeDto
    {
        public string Specialization { get; set; } = string.Empty;
        public string? Certification { get; set; }
        public TimeOnly? AvailableFrom { get; set; }
        public TimeOnly? AvailableTo { get; set; }
        public ICollection<RetrieveCustomerDto> Customers { get; set; } = [];
    }
}
