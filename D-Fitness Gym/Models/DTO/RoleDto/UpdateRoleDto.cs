using System.ComponentModel.DataAnnotations;

namespace D_Fitness_Gym.Models.DTO.RoleDto
{
    public class UpdateRoleDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "Minimum length should be 1")]
        [MaxLength(50, ErrorMessage = "Maximum length should be 50")]
        public string Name { get; set; }
    }
}
