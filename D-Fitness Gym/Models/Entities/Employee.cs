using D_Fitness_Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D_Fitness_Gym.Models.Entities
{
    public class Employee : Account
    {

        [Required]
        [StringLength(100)]
        public string JobTitle { get; set; } = string.Empty;

        [Required]
        public int Salary { get; set; }

        [Required, Range(0, 60)]
        public int YearsOfExperience { get; set; }

        public string? Bio { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        public Status Status { get; set; } = Status.Active;

    }
}