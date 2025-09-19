using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Models.Enums;

namespace D_Fitness_Gym.Models.DTO.AccountDto
{
    public class UpdateAccountDto
    {
        public  string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string? Description { get; set; }
        public DateOnly JoinedDate { get; set; }
    }
}
