using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Models.Enums;

namespace D_Fitness_Gym.Models.DTO.AccountDto
{
    public class CreateAccountDto
    {
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
