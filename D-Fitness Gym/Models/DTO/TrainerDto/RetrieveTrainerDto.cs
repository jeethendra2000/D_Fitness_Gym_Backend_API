namespace D_Fitness_Gym.Models.DTO.TrainerDto
{
    public class RetrieveTrainerDto 
    {
        public Guid Id { get; set; }
        public int Experience { get; set; }
        public TimeOnly AvailableFrom { get; set; }
        public TimeOnly AvailableTo { get; set; }

        // Navigation Properties
    }
}
