using D_Fitness_Gym.CustomActionFilters;
using D_Fitness_Gym.Models.DTO.SubscriptionDto;
using D_Fitness_Gym.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace D_Fitness_Gym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController(ISubscriptionService subscriptionService) : ControllerBase
    {

        private readonly ISubscriptionService _subscriptionService = subscriptionService ?? throw new ArgumentNullException(nameof(subscriptionService));

        /// <summary>
        /// Retrieves all Subscriptions.
        /// </summary>
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllSubscriptions(string? filterOn, string? filterBy, string? sortOn, bool? isAscending, int? pageNo, int? pageSize, [FromQuery] string[]? includes)
        {
            var allSubscriptions = await _subscriptionService.GetAllAsync(filterOn, filterBy, sortOn, isAscending, pageNo, pageSize, includes);

            if (allSubscriptions == null || !allSubscriptions.Data.Any())
                return NoContent();

            return Ok(allSubscriptions);
        }

        [HttpGet("{id:guid}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetSubscriptionById(Guid id)
        {
            var subscription = await _subscriptionService.GetByIdAsync(id);

            if (subscription == null)
                return NotFound();

            return Ok(subscription);
        }

        [HttpPost]
        [ValidateModel]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateSubscription(CreateSubscriptionDto createSubscriptionDto)
        {
            var subscription = await _subscriptionService.CreateAsync(createSubscriptionDto);

            return CreatedAtAction(nameof(GetSubscriptionById), new { id = subscription.Id }, subscription);
        }

        [HttpPatch("{id:guid}")]
        [ValidateModel]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateSubscription(Guid id, UpdateSubscriptionDto updateSubscriptionDto)
        {
            var subscription = await _subscriptionService.UpdateAsync(id, updateSubscriptionDto);

            if (subscription == null)
                return NotFound();

            return Ok(subscription);
        }

        [HttpDelete("{id:guid}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteSubscription(Guid id)
        {
            try
            {
                var isDeleted = await _subscriptionService.DeleteAsync(id);
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
