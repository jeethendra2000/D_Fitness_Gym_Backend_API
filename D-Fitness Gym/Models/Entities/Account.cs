using D_Fitness_Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D_Fitness_Gym.Models.Entities
{
    public class Account
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [Required]
        [StringLength(100)]
        public required string Firstname { get; set; }

        [Required]
        [StringLength(100)]
        public required string Lastname { get; set; }

        [Required]
        public required string Email { get; set; }
        [Required]
        public required string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string? ProfileImageUrl { get; set; }

    }
}
