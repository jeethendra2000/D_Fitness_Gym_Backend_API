using AutoMapper;
using D_Fitness_Gym.Models.DTO.RoleDto;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Repositories.Interfaces;
using D_Fitness_Gym.Services.Interfaces;

namespace D_Fitness_Gym.Services
{
    // Business logic layer
    public class RoleService(IRoleRepository roleRepository, IMapper mapper, ILogger<RoleService> logger) : 
        BaseService<Role, CreateRoleDto, UpdateRoleDto, RetrieveRoleDto>(roleRepository, mapper, logger), IRoleService
    {
        private readonly IRoleRepository _roleRepository = roleRepository;

        /// <summary>
        /// Deletes a role by its ID, preventing deletion of system roles.
        /// </summary>
        public override async Task<bool> DeleteAsync(Guid id)
        {
            _logger.LogInformation($"Attempting to delete Role with ID: {id}");

            // ❌ Prevent deleting system roles
            if (id == Guid.Parse("11111111-1111-1111-1111-111111111111") ||
                id == Guid.Parse("22222222-2222-2222-2222-222222222222") ||
                id == Guid.Parse("33333333-3333-3333-3333-333333333333"))
            {
                _logger.LogError($"{typeof(Role).Name} with ID: {id} could not be deleted because System roles cannot be deleted.");
                throw new InvalidOperationException("System roles cannot be deleted.");
            }

            // Check if the entity exists before deleting it
            var existingRecord = await CheckIfRecordExistsAsync(id);
            if (existingRecord == null)
            {
                _logger.LogWarning($"{typeof(Role).Name} with ID: {id} not found for deletion.");
                return false;
            }
            // Delete the entity from the repository and return the status
            var isDeleted = await _baseRepository.DeleteAsync(existingRecord);
            if (isDeleted)
                _logger.LogInformation($"{typeof(Role).Name} with ID: {id} deleted successfully.");
            else
                _logger.LogWarning($"{typeof(Role).Name} with ID: {id} could not be deleted.");

            return isDeleted;
        }
    }
}
