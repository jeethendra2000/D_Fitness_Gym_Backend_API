using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D_Fitness_Gym.Models.Entities
{
    public class Customer : Account
    {

        [Range(0, 300)]
        public double Height { get; set; }

        [Range(0, 300)]
        public double Weight { get; set; }

        public bool TrainerRequired { get; set; } = false;

        // Navigation Properties
        public Guid? TrainerId { get; set; }

        [ForeignKey(nameof(TrainerId))]
        public Trainer? Trainer { get; set; }

        // Use ICollection or List for navigation
        public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();

    }
}