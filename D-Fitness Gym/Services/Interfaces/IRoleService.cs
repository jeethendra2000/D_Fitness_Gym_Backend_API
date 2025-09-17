using D_Fitness_Gym.Models.DTO.RoleDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Services.Interfaces
{
    public interface IRoleService : IBaseService<Role, CreateRoleDto, UpdateRoleDto, RetrieveRoleDto>
    {
        // Extra Business logic layer
        Task<RetrieveRoleDto?> GetRoleByName(string name);
    }
}
