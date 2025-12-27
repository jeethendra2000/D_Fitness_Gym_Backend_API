using D_Fitness_Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.Entities
{
    public class Enquiry
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(150)]
        public required string FullName { get; set; } = string.Empty;
        
        [EmailAddress]
        [MaxLength(150)]
        public required string Email { get; set; } = string.Empty;

        [MaxLength(15)]
        public required string PhoneNumber { get; set; } = string.Empty;

        public required string Message { get; set; } = string.Empty;

        [MaxLength(20)]
        public required EnquiryStatus Status { get; set; } = EnquiryStatus.New;
        public required DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    }
}
