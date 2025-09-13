using D_Fitness_Gym.Models.DTO;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Repositories.Interfaces;
using D_Fitness_Gym.Services.Interfaces;

namespace D_Fitness_Gym.Services
{
    // Business logic layer
    public class RoleService(IRoleRepository repository) : IRoleService
    {
        private readonly IRoleRepository _repository = repository;

        public async Task<IEnumerable<Role>> GetAllRolesAsync() => await _repository.GetAllRolesAsync();

        public async Task<Role?> GetRoleByIdAsync(Guid id) => await _repository.GetRoleByIdAsync(id);
       
        public async Task<Role> CreateRoleAsync(RoleDto roleDto)
        {
            var role = new Role { Name = roleDto.Name };

            return await _repository.CreateRoleAsync(role);
        }

        public async Task<Role?> UpdateRoleAsync(Guid id, RoleDto roleDto)
        {
            var existingRole = await _repository.GetRoleByIdAsync(id);

            if (existingRole == null) 
                return existingRole;

            existingRole.Name = roleDto.Name;

            return await _repository.UpdateRoleAsync(existingRole);
        }

        public async Task<bool> DeleteRoleAsync(Guid id)
        {
            // ❌ Prevent deleting system roles
            if (id == Guid.Parse("11111111-1111-1111-1111-111111111111") ||
                id == Guid.Parse("22222222-2222-2222-2222-222222222222") ||
                id == Guid.Parse("33333333-3333-3333-3333-333333333333"))
            {
                throw new InvalidOperationException("System roles cannot be deleted.");
            }

            return await _repository.DeleteRoleAsync(id);
        }
    }
}
