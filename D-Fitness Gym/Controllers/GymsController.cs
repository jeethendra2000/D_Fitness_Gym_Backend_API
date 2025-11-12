using D_Fitness_Gym.CustomActionFilters;
using D_Fitness_Gym.Models.DTO.GymDto;
using D_Fitness_Gym.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace D_Fitness_Gym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymsController(IGymService gymService) : ControllerBase
    {
        private readonly IGymService _gymService = gymService ?? throw new ArgumentNullException(nameof(gymService));

        /// <summary>
        /// Retrieves all gyms.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllGyms(string? filterOn, string? filterBy, string? sortOn, bool? isAscending, int? pageNo, int? pageSize)
        {
            var allGyms = await _gymService.GetAllAsync(filterOn, filterBy, sortOn, isAscending, pageNo, pageSize);

            if (allGyms == null || !allGyms.Data.Any())
                return NoContent(); // Return 204 if no gyms are found

            // Return 200 with the gyms
            return Ok(allGyms);
        }

        /// <summary>
        /// Retrieves a gym by its ID.
        /// </summary>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetGymById(Guid id)
        {
            var gym = await _gymService.GetByIdAsync(id);

            if (gym == null)
                return NotFound(); // Return 404 if the gym is not found

            // Return 200 with the found gym
            return Ok(gym);
        }

        /// <summary>
        /// Creates a new gym.
        /// </summary>
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateGym(CreateGymDto gymDto)
        {
            var gym = await _gymService.CreateAsync(gymDto);

            // Return 201 with the created gym
            return CreatedAtAction(nameof(GetGymById), new { id = gym.Id }, gym);
        }

        /// <summary>
        /// Updates an existing gym.
        /// </summary>
        [HttpPatch("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateGym(Guid id, UpdateGymDto gymDto)
        {
            var gym = await _gymService.UpdateAsync(id, gymDto); // Return 404 if the gym was not found

            if (gym == null)
                return NotFound();

            // Return 200 with the updated gym
            return Ok(gym);
        }

        /// <summary>
        /// Deletes a gym by its ID.
        /// </summary>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteGym(Guid id)
        {
            try
            {
                var isDeleted = await _gymService.DeleteAsync(id);

                // Return 404 if the gym wasn't found
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
