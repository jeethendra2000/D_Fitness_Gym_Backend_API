using D_Fitness_Gym.CustomActionFilters;
using D_Fitness_Gym.Models.DTO.EnquiryDto;
using D_Fitness_Gym.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace D_Fitness_Enquiry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnquiriesController(IEnquiryService enquiryService) : ControllerBase
    {
        private readonly IEnquiryService _enquiryService = enquiryService ?? throw new ArgumentNullException(nameof(enquiryService));

        /// <summary>
        /// Retrieves all enquirys.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllEnquirys(string? filterOn, string? filterBy, string? sortOn, bool? isAscending, int? pageNo, int? pageSize)
        {
            var allEnquirys = await _enquiryService.GetAllAsync(filterOn, filterBy, sortOn, isAscending, pageNo, pageSize);

            if (allEnquirys == null || !allEnquirys.Data.Any())
                return NoContent(); // Return 204 if no enquirys are found

            // Return 200 with the enquirys
            return Ok(allEnquirys);
        }

        /// <summary>
        /// Retrieves a enquiry by its ID.
        /// </summary>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetEnquiryById(Guid id)
        {
            var enquiry = await _enquiryService.GetByIdAsync(id);

            if (enquiry == null)
                return NotFound(); // Return 404 if the enquiry is not found

            // Return 200 with the found enquiry
            return Ok(enquiry);
        }

        /// <summary>
        /// Creates a new enquiry.
        /// </summary>
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateEnquiry(CreateEnquiryDto enquiryDto)
        {
            var enquiry = await _enquiryService.CreateAsync(enquiryDto);

            // Return 201 with the created enquiry
            return CreatedAtAction(nameof(GetEnquiryById), new { id = enquiry.Id }, enquiry);
        }

        /// <summary>
        /// Updates an existing enquiry.
        /// </summary>
        [HttpPut("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateEnquiry(Guid id, UpdateEnquiryDto enquiryDto)
        {
            var enquiry = await _enquiryService.UpdateAsync(id, enquiryDto); // Return 404 if the enquiry was not found

            if (enquiry == null)
                return NotFound();

            // Return 200 with the updated enquiry
            return Ok(enquiry);
        }

        /// <summary>
        /// Deletes a enquiry by its ID.
        /// </summary>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEnquiry(Guid id)
        {
            try
            {
                var isDeleted = await _enquiryService.DeleteAsync(id);

                // Return 404 if the enquiry wasn't found
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
