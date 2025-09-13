namespace D_Fitness_Gym.Models.Entities
{
    public class Role
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }

        public List<Account>? Accounts { get; set; }
    }
}
