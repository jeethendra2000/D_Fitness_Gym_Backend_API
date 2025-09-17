using D_Fitness_Gym.Data;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace D_Fitness_Gym.Repositories
{
    // Data access layer
    public class RoleRepository(ApplicationDbContext dbContext) : BaseRepository<Role>(dbContext), IRoleRepository
    {
        // Role-specific methods can be added here
        // Querying by a unique Name (non-primary key field) using FirstOrDefaultAsync
        public async Task<Role?> GetRoleByNameAsync(string name) => await _dbContext.Roles.FirstOrDefaultAsync(role => role.Name == name);
    }
}
