using D_Fitness_Gym.Models.Enums;

namespace D_Fitness_Gym.Models.DTO.AccountDto
{
    public class RetrieveAccountDto
    {
        public Guid Id { get; set; }

        public string Firstname { get; set; } = default!;
        public string Lastname { get; set; } = default!;
        public string Email { get; set; } = default!;

        public Gender Gender { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public string PhoneNumber { get; set; } = default!;

        public string? Address { get; set; }

        public string? Description { get; set; }

        public DateOnly JoinedDate { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
