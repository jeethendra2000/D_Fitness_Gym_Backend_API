using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Repositories.Interfaces
{
    // Data access layer
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role?> GetRoleByIdAsync(Guid id);
        Task<Role> CreateRoleAsync(Role role);
        Task<Role?> UpdateRoleAsync(Role role);
        Task<bool> DeleteRoleAsync(Guid id);
    }
}
