using D_Fitness_Gym.CustomActionFilters;
using D_Fitness_Gym.Models.DTO.MembershipDto;
using D_Fitness_Gym.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace D_Fitness_Gym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipsController(IMembershipService membershipService) : ControllerBase
    {
        private readonly IMembershipService _membershipService = membershipService ?? throw new ArgumentNullException(nameof(membershipService));

        /// <summary>
        /// Retrieves all memberships.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllMemberships(string? filterOn, string? filterBy, string? sortOn, bool? isAscending, int? pageNo, int? pageSize, [FromQuery] string[]? includes)
        {
            //string[]? includes = ["Role"];
            var allUsers = await _membershipService.GetAllAsync(filterOn, filterBy, sortOn, isAscending, pageNo, pageSize, includes);

            if (allUsers == null || !allUsers.Data.Any())
                return NoContent();

            return Ok(allUsers);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetMembershipById(Guid id)
        {
            var membership = await _membershipService.GetByIdAsync(id);

            if (membership == null)
                return NotFound();

            return Ok(membership);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateMembership(CreateMembershipDto createMembershipDto)
        {
            var membership = await _membershipService.CreateAsync(createMembershipDto);

            return CreatedAtAction(nameof(GetMembershipById), new { id = membership.Id }, membership);
        }

        [HttpPatch("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateMembership(Guid id, UpdateMembershipDto updateMembershipDto)
        {
            var membership = await _membershipService.UpdateAsync(id, updateMembershipDto);

            if (membership == null)
                return NotFound();

            return Ok(membership);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteMembership(Guid id)
        {
            try
            {
                var isDeleted = await _membershipService.DeleteAsync(id);
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
