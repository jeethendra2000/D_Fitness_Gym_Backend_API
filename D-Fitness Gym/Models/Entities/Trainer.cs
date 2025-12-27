using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D_Fitness_Gym.Models.Entities
{
    public class Trainer : Employee
    {
        [Required, StringLength(100)]
        public string Specialization { get; set; } = string.Empty;

        [Required, Range(0, 60)]
        public int YearsOfExperience { get; set; }
        public string? Bio { get; set; }

        [StringLength(150)]
        public string? Certification { get; set; }

        [Column(TypeName = "decimal(2,1)")]
        [Range(0.0, 5.0)]
        public decimal? Rating { get; set; }

        public TimeOnly? AvailableFrom { get; set; }
        public TimeOnly? AvailableTo { get; set; }

        // Navigation Properties
        public List<Customer> Customers { get; set; } = [];
    }
}