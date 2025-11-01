using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.Entities
{
    public class Gym
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(150)]
        public required string Name { get; set; } = string.Empty;

        [StringLength(250)]
        public string? Address { get; set; }

        [StringLength(100)]
        public string? City { get; set; }

        [StringLength(15)]
        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Website { get; set; }
       
        public string? ManagedByFirebaseUID { get; set; }  // Firebase ID of the gym owner or manager
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<Customer>? Customers { get; set; }
        public ICollection<Subscription>? Subscriptions { get; set; }
    }
}
