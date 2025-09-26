using D_Fitness_Gym.CustomActionFilters;
using D_Fitness_Gym.Models.DTO.UserDto;
using D_Fitness_Gym.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace D_Fitness_Gym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService ?? throw new ArgumentNullException(nameof(userService));

        /// <summary>
        /// Retrieves all User.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllUsers(string? filterOn, string? filterBy, string? sortOn, bool? isAscending, int? pageNo, int? pageSize, [FromQuery] string[]? includes)
        {
            var allUsers = await _userService.GetAllAsync(filterOn, filterBy, sortOn, isAscending, pageNo, pageSize, includes);

            if (allUsers == null || !allUsers.Data.Any())
                return NoContent();

            return Ok(allUsers);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            var user = await _userService.CreateAsync(createUserDto);

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPatch("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateUser(Guid id, UpdateUserDto updateUserDto)
        {
            var user = await _userService.UpdateAsync(id, updateUserDto);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                var isDeleted = await _userService.DeleteAsync(id);
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
