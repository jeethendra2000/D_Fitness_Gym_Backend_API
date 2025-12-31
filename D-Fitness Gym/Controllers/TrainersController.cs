using D_Fitness_Gym.CustomActionFilters;
using D_Fitness_Gym.Models.DTO.TrainerDto;
using D_Fitness_Gym.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace D_Fitness_Gym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController(ITrainerService trainerService) : ControllerBase
    {
        private readonly ITrainerService _trainerService = trainerService;

        /// <summary>
        /// Retrieves all Trainers.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllTrainers(string? filterOn, string? filterBy, string? sortOn, bool? isAscending, int? pageNo, int? pageSize, [FromQuery] string[]? includes)
        {
            //string[]? includes = ["Role"];
            var allUsers = await _trainerService.GetAllAsync(filterOn, filterBy, sortOn, isAscending, pageNo, pageSize, includes);

            if (allUsers == null || !allUsers.Data.Any())
                return NoContent();

            return Ok(allUsers);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetTrainerById(Guid id)
        {
            var trainer = await _trainerService.GetByIdAsync(id);

            if (trainer == null)
                return NotFound();

            return Ok(trainer);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateTrainer([FromForm] CreateTrainerDto createTrainerDto)
        {
            var trainer = await _trainerService.CreateAsync(createTrainerDto);

            return CreatedAtAction(nameof(GetTrainerById), new { id = trainer.Id }, trainer);
        }

        [HttpPatch("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateTrainer(Guid id, [FromForm] UpdateTrainerDto updateTrainerDto)
        {
            var trainer = await _trainerService.UpdateAsync(id, updateTrainerDto);

            if (trainer == null)
                return NotFound();

            return Ok(trainer);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTrainer(Guid id)
        {
            try
            {
                var isDeleted = await _trainerService.DeleteAsync(id);
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
