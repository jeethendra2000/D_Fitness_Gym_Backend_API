namespace D_Fitness_Gym.Models.DTO.TrainerDto
{
    public class UpdateTrainerDto
    {
        public int Experience { get; set; }
        public TimeOnly AvailableFrom { get; set; }
        public TimeOnly AvailableTo { get; set; }

        // Navigation Properties
    }
}
