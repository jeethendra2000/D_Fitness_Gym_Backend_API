using D_Fitness_Gym.Models.Enums;

namespace D_Fitness_Gym.Models.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }

        // Unique constraint in DbContext
        public required string Email { get; set; }

        // Store hashed password, not plain text
        public required string PasswordHash { get; set; }
        public required string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string? Description { get; set; }
        public DateOnly JoinedDate { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        // Foreign Key
        public Guid RoleId { get; set; }

        // Relationship / Navigation Properties
        public Role Role { get; set; }
        public List<Transaction> TransactionsAsPayer { get; set; } = [];
        public List<Transaction> TransactionsAsPayee { get; set; } = [];
    }
}
