using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D_Fitness_Gym.Models.Entities
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [Required]
        [StringLength(100)]
        public string Firebase_UID { get; set; } = string.Empty; // Firebase UID linking to Django user profile

        [Range(0, 300)]
        public double Height { get; set; }

        [Range(0, 300)]
        public double Weight { get; set; }

        public bool TrainerRequired { get; set; } = false;

        public Guid? TrainerId { get; set; }
        
        [Required]
        public Guid GymId { get; set; } // Gym reference

        // Foreign Key
        [ForeignKey(nameof(TrainerId))]
        public Trainer? Trainer { get; set; }

        // Navigation Properties
        public Gym Gym { get; set; } = null!;
        public List<Subscription> Subscriptions { get; set; } = [];

        // 🔗 Optional: For external linking (not stored in DB)
        [NotMapped]
        public string? DjangoProfileURL { get; set; }
    }
}
