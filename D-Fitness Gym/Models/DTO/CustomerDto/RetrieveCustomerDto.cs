using D_Fitness_Gym.Models.DTO.AccountDto;

namespace D_Fitness_Gym.Models.DTO.CustomerDto
{
    public class RetrieveCustomerDto : RetrieveAccountDto
    {
        public double Height { get; set; }
        public double Weight { get; set; }
        public bool TrainerRequired { get; set; }
        public DateOnly JoinedDate { get; set; }
        public Guid? TrainerId { get; set; }
    }
}
