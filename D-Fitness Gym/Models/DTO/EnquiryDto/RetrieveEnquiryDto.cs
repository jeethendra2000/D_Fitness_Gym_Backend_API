using D_Fitness_Gym.Models.Enums;

namespace D_Fitness_Gym.Models.DTO.EnquiryDto
{
    public class RetrieveEnquiryDto
    {
        public Guid Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public EnquiryStatus Status { get; set; }

        public DateTime SubmittedAt { get; set; }
    }
}
