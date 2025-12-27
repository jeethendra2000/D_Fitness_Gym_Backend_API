using D_Fitness_Gym.Models.DTO.AdminDto;

namespace D_Fitness_Gym.Models.DTO.GymDto
{
    public class RetrieveGymDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? ManagedByFirebaseUID { get; set; }
        public DateTime CreatedOn { get; set; }

        // Optional navigation details (for expanded responses)
        public int? EmployeeCount { get; set; }
        public int? CustomerCount { get; set; }
        public int? ActiveSubscriptions { get; set; }

        // Navigation Property
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] // If Admin is null, the serialized JSON will simply omit the Admin property instead of showing "admin": null.
        public RetrieveAdminDto? Admin { get; set; }
    }
}
