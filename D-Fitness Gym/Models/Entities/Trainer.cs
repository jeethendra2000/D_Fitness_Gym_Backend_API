using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D_Fitness_Gym.Models.Entities
{
    public class Trainer : Employee
    {
        [Required, StringLength(100)]
        public string Specialization { get; set; } = string.Empty;

        [StringLength(150)]
        public string? Certification { get; set; }

        public TimeOnly? AvailableFrom { get; set; }
        public TimeOnly? AvailableTo { get; set; }

        // Navigation Properties
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
    }
}