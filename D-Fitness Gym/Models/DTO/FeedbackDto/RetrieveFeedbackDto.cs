using System;

namespace D_Fitness_Gym.Models.DTO.FeedbackDto
{
    public class RetrieveFeedbackDto
    {
        public Guid Id { get; set; }
        public string Firebase_UID { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public int? Rating { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime SubmittedAt { get; set; }
    }
}
