namespace D_Fitness_Gym.Models.Entities
{
    public class User : Account
    {
        public double Height { get; set; }
        public double Weight { get; set; }
        public bool TrainerRequired { get; set; } = false;

        // Foreign Key
        public Guid TrainerId {  get; set; }

        // Navigation Properties
        public Trainer Trainer { get; set; } = null!;
        public List<Subscription> Subscriptions { get; set; }
    }
}
