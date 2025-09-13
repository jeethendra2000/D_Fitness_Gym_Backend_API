using D_Fitness_Gym.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.DTO
{
    public class RoleDto
    {
        [Required]
        public required string Name { get; set; }
    }
}
