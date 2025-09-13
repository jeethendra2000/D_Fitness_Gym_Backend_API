using D_Fitness_Gym.Models.DTO;
using D_Fitness_Gym.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace D_Fitness_Gym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController(IRoleService roleService) : ControllerBase
    {
        private readonly IRoleService _roleService = roleService;

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var allRoles = await _roleService.GetAllRolesAsync();

            return Ok(allRoles);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetRoleById(Guid id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);

            if (role == null)
                return NotFound();
            
            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleDto roleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var role = await _roleService.CreateRoleAsync(roleDto);

            return CreatedAtAction(nameof(GetRoleById), new { id = role.Id }, role);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateRole(Guid id, RoleDto roleDto)
        {
            var role = await _roleService.UpdateRoleAsync(id, roleDto);

            if (role == null)
                return NotFound();

            return Ok(role);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            try
            {
                var isDeleted = await _roleService.DeleteRoleAsync(id);
                if (!isDeleted) return NotFound();
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
