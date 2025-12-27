using System;
using System.ComponentModel.DataAnnotations;
using D_Fitness_Gym.Models.Enums;

namespace D_Fitness_Gym.Models.Entities
{
    public class Feedback
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(150)]
        public required string Subject { get; set; } = string.Empty;

        public required string Message { get; set; } = string.Empty;

        [Range(1, 5)]
        public int? Rating { get; set; }

        public required FeedbackStatus Status { get; set; } = FeedbackStatus.New;

        public required DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    }
}
