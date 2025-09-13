using D_Fitness_Gym.Models.DTO;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Services.Interfaces
{
    // Business logic layer
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role?> GetRoleByIdAsync(Guid id);
        Task<Role> CreateRoleAsync(RoleDto roleDto);
        Task<Role?> UpdateRoleAsync(Guid id, RoleDto roleDto);
        Task<bool> DeleteRoleAsync(Guid id);
    }
}
