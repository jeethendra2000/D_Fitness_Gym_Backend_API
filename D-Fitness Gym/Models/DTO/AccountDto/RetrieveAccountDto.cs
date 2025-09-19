using D_Fitness_Gym.Models.DTO.RoleDto;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Models.Enums;

namespace D_Fitness_Gym.Models.DTO.AccountDto
{
    public class RetrieveAccountDto
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string? Description { get; set; }
        public DateOnly JoinedDate { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public Guid RoleId { get; set; }

        public RetrieveRoleDto RetrieveRoleDto { get; set; }
    }
}
