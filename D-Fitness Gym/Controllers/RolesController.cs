using D_Fitness_Gym.CustomActionFilters;
using D_Fitness_Gym.Models.DTO.RoleDto;
using D_Fitness_Gym.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace D_Fitness_Gym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController(IRoleService roleService) : ControllerBase
    {
        private readonly IRoleService _roleService = roleService ?? throw new ArgumentNullException(nameof(roleService));

        /// <summary>
        /// Retrieves all roles.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllRoles(string? filterOn, string?filterBy, string?sortOn, bool? isAscending, int?pageNo, int?pageSize)
        {
            var allRoles = await _roleService.GetAllAsync(filterOn, filterBy, sortOn, isAscending, pageNo, pageSize);

            if (allRoles == null || !allRoles.Any())
                return NoContent(); // Return 204 if no roles are found

            // Return 200 with the roles
            return Ok(allRoles);
        }

        /// <summary>
        /// Retrieves a role by its ID.
        /// </summary>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetRoleById(Guid id)
        {
            var role = await _roleService.GetByIdAsync(id);

            if (role == null)
                return NotFound(); // Return 404 if the role is not found

            // Return 200 with the found role
            return Ok(role); 
        }

        /// <summary>
        /// Creates a new role.
        /// </summary>
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateRole(CreateRoleDto roleDto)
        {
            var role = await _roleService.CreateAsync(roleDto);

            // Return 201 with the created role
            return CreatedAtAction(nameof(GetRoleById), new { id = role.Id }, role);
        }

        /// <summary>
        /// Updates an existing role.
        /// </summary>
        [HttpPut("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateRole(Guid id, UpdateRoleDto roleDto)
        {
            var role = await _roleService.UpdateAsync(id, roleDto); // Return 404 if the role was not found

            if (role == null)
                return NotFound();

            // Return 200 with the updated role
            return Ok(role);
        }

        /// <summary>
        /// Deletes a role by its ID.
        /// </summary>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            try
            {
                var isDeleted = await _roleService.DeleteAsync(id);
                
                // Return 404 if the role wasn't found
                if (!isDeleted) 
                    return NotFound();

                // Return 204 on successful deletion
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                // Return 400 with error message for invalid deletion attempt
                return BadRequest(ex.Message);
            }
        }
    }
}
