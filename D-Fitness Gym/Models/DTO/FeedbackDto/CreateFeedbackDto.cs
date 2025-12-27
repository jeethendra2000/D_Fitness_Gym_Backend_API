using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.DTO.FeedbackDto
{
    public class CreateFeedbackDto
    {
        public required string Firebase_UID { get; set; } = string.Empty;

        [MaxLength(150)]
        public required string Subject { get; set; } = string.Empty;

        public required string Message { get; set; } = string.Empty;

        [Range(1, 5)]
        public int? Rating { get; set; }
    }
}
