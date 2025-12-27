using D_Fitness_Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D_Fitness_Gym.Models.Entities
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string Firebase_UID { get; set; } = string.Empty; // Firebase UID for linking with Django UserProfile

        [Required]
        [StringLength(100)]
        public string JobTitle { get; set; } = string.Empty;

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        public Status Status { get; set; } = Status.Active;

        // Foreign Key
        public Guid? ReportsToEmployeeID { get; set; } // Self-referencing foreign key (manager)

        // Navigation Properties
        [ForeignKey(nameof(ReportsToEmployeeID))]
        public Employee? ReportsTo { get; set; }
        public ICollection<Employee>? Subordinates { get; set; }
        
        // 🔗 Optional link to Django UserProfile (virtual only)
        [NotMapped]
        public string? DjangoProfileURL { get; set; }
    }
}        
