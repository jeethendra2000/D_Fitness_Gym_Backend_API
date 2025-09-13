using D_Fitness_Gym.Data;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace D_Fitness_Gym.Repositories
{
    // Data access layer
    public class RoleRepository(ApplicationDbContext dbContext) : IRoleRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<IEnumerable<Role>> GetAllRolesAsync() => await _dbContext.Roles.ToListAsync();
        public async Task<Role?> GetRoleByIdAsync(Guid id) => await _dbContext.Roles.FindAsync(id);
        public async Task<Role> CreateRoleAsync(Role role)
        {
            _dbContext.Roles.Add(role);
            await _dbContext.SaveChangesAsync();
            return role;
        }
        public async Task<Role?> UpdateRoleAsync(Role role)
        {
            var existingRole = await _dbContext.Roles.FindAsync(role.Id);
            if (existingRole == null) return null;

            existingRole.Name = role.Name;
            await _dbContext.SaveChangesAsync();

            return existingRole;
        }
        public async Task<bool> DeleteRoleAsync(Guid id)
        {
            var role = await _dbContext.Roles.FindAsync(id);
            if (role == null) return false;

            _dbContext.Roles.Remove(role);
            await _dbContext.SaveChangesAsync();
            
            return true;
        }

    }
}
