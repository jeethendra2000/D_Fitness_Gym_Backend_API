using System.ComponentModel.DataAnnotations;
using D_Fitness_Gym.Models.Enums;

namespace D_Fitness_Gym.Models.DTO.FeedbackDto
{
    public class UpdateFeedbackDto
    {
        [MaxLength(150)]
        public string? Subject { get; set; }

        public string? Message { get; set; }

        [Range(1, 5)]
        public int? Rating { get; set; }

        public FeedbackStatus? Status { get; set; }
    }
}
