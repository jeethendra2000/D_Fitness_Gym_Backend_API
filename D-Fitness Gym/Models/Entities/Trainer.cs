namespace D_Fitness_Gym.Models.Entities
{
    public class Trainer : Account
    {
        public int Experience { get; set; }
        public TimeOnly AvailableFrom { get; set; }
        public TimeOnly AvailableTo { get; set; }

        // Relationship / Navigation Properties
        public List<User> Users { get; set; } = [];
    }
}
