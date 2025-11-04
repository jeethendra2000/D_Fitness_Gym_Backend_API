using D_Fitness_Gym.CustomActionFilters;
using D_Fitness_Gym.Models.DTO.OfferDto;
using D_Fitness_Gym.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace D_Fitness_Offer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController(IOfferService offerService) : ControllerBase
    {
        private readonly IOfferService _offerService = offerService ?? throw new ArgumentNullException(nameof(offerService));

        /// <summary>
        /// Retrieves all offers.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllOffers(string? filterOn, string? filterBy, string? sortOn, bool? isAscending, int? pageNo, int? pageSize)
        {
            var allOffers = await _offerService.GetAllAsync(filterOn, filterBy, sortOn, isAscending, pageNo, pageSize);

            if (allOffers == null || !allOffers.Data.Any())
                return NoContent(); // Return 204 if no offers are found

            // Return 200 with the offers
            return Ok(allOffers);
        }

        /// <summary>
        /// Retrieves a offer by its ID.
        /// </summary>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOfferById(Guid id)
        {
            var offer = await _offerService.GetByIdAsync(id);

            if (offer == null)
                return NotFound(); // Return 404 if the offer is not found

            // Return 200 with the found offer
            return Ok(offer);
        }

        /// <summary>
        /// Creates a new offer.
        /// </summary>
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateOffer(CreateOfferDto offerDto)
        {
            var offer = await _offerService.CreateAsync(offerDto);

            // Return 201 with the created offer
            return CreatedAtAction(nameof(GetOfferById), new { id = offer.Id }, offer);
        }

        /// <summary>
        /// Updates an existing offer.
        /// </summary>
        [HttpPut("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateOffer(Guid id, UpdateOfferDto offerDto)
        {
            var offer = await _offerService.UpdateAsync(id, offerDto); // Return 404 if the offer was not found

            if (offer == null)
                return NotFound();

            // Return 200 with the updated offer
            return Ok(offer);
        }

        /// <summary>
        /// Deletes a offer by its ID.
        /// </summary>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteOffer(Guid id)
        {
            try
            {
                var isDeleted = await _offerService.DeleteAsync(id);

                // Return 404 if the offer wasn't found
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
