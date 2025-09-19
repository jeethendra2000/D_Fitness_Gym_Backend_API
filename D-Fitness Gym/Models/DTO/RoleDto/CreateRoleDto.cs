using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.DTO.RoleDto
{
    public class CreateRoleDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "Minimum length should be 1")]
        [MaxLength(50, ErrorMessage = "Maximum length should be 50")]
        public required string Name { get; set; }
    }
}
