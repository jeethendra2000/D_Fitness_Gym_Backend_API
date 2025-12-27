namespace D_Fitness_Gym.Models.DTO.CustomerDto
{
    public class RetrieveCustomerDto
    {
        public Guid Id { get; set; }
        public string Firebase_UID { get; set; } = string.Empty;
        public double Height { get; set; }
        public double Weight { get; set; }
        public bool TrainerRequired { get; set; }
        public Guid? TrainerId { get; set; }
    }
}
