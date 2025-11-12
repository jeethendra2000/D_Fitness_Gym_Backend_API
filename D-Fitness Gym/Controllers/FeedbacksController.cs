using D_Fitness_Gym.CustomActionFilters;
using D_Fitness_Gym.Models.DTO.FeedbackDto;
using D_Fitness_Gym.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace D_Fitness_Feedback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController(IFeedbackService feedbackService) : ControllerBase
    {
        private readonly IFeedbackService _feedbackService = feedbackService ?? throw new ArgumentNullException(nameof(feedbackService));

        /// <summary>
        /// Retrieves all feedbacks.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllFeedbacks(string? filterOn, string? filterBy, string? sortOn, bool? isAscending, int? pageNo, int? pageSize)
        {
            var allFeedbacks = await _feedbackService.GetAllAsync(filterOn, filterBy, sortOn, isAscending, pageNo, pageSize);

            if (allFeedbacks == null || !allFeedbacks.Data.Any())
                return NoContent(); // Return 204 if no feedbacks are found

            // Return 200 with the feedbacks
            return Ok(allFeedbacks);
        }

        /// <summary>
        /// Retrieves a feedback by its ID.
        /// </summary>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetFeedbackById(Guid id)
        {
            var feedback = await _feedbackService.GetByIdAsync(id);

            if (feedback == null)
                return NotFound(); // Return 404 if the feedback is not found

            // Return 200 with the found feedback
            return Ok(feedback);
        }

        /// <summary>
        /// Creates a new feedback.
        /// </summary>
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateFeedback(CreateFeedbackDto feedbackDto)
        {
            var feedback = await _feedbackService.CreateAsync(feedbackDto);

            // Return 201 with the created feedback
            return CreatedAtAction(nameof(GetFeedbackById), new { id = feedback.Id }, feedback);
        }

        /// <summary>
        /// Updates an existing feedback.
        /// </summary>
        [HttpPatch("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateFeedback(Guid id, UpdateFeedbackDto feedbackDto)
        {
            var feedback = await _feedbackService.UpdateAsync(id, feedbackDto); // Return 404 if the feedback was not found

            if (feedback == null)
                return NotFound();

            // Return 200 with the updated feedback
            return Ok(feedback);
        }

        /// <summary>
        /// Deletes a feedback by its ID.
        /// </summary>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteFeedback(Guid id)
        {
            try
            {
                var isDeleted = await _feedbackService.DeleteAsync(id);

                // Return 404 if the feedback wasn't found
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
