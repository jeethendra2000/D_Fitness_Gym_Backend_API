using D_Fitness_Gym.Models.Enums;

namespace D_Fitness_Gym.Models.DTO.AccountDto
{
    public class RetrieveAccountDto
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string FullName => $"{Firstname} {Lastname}";
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ProfileImageUrl { get; set; }
    }
}
