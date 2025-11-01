using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D_Fitness_Gym.Models.Entities
{
    public class Admin
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [Required]
        [StringLength(100)]
        public string Firebase_UID { get; set; } = string.Empty; // Firebase UID for linking with Django UserProfile
                                                                 
        [Required]
        public Guid GymId { get; set; } // Gym Reference

        // Navigation Properties
        public Gym Gym { get; set; } = null!;

        // 🔗 Optional: For external linking (not stored in DB)
        [NotMapped]
        public string? DjangoProfileURL { get; set; }
    }
}
