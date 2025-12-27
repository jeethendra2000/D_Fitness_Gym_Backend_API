using D_Fitness_Gym.CustomActionFilters;
using D_Fitness_Gym.Models.DTO.CustomerDto;
using D_Fitness_Gym.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace D_Fitness_Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(ICustomerService customerService) : ControllerBase
    {
        private readonly ICustomerService _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));

        /// <summary>
        /// Retrieves all customers.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers(string? filterOn, string? filterBy, string? sortOn, bool? isAscending, int? pageNo, int? pageSize)
        {
            var allCustomers = await _customerService.GetAllAsync(filterOn, filterBy, sortOn, isAscending, pageNo, pageSize);

            if (allCustomers == null || !allCustomers.Data.Any())
                return NoContent(); // Return 204 if no customers are found

            // Return 200 with the customers
            return Ok(allCustomers);
        }

        /// <summary>
        /// Retrieves a customer by its ID.
        /// </summary>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            var customer = await _customerService.GetByIdAsync(id);

            if (customer == null)
                return NotFound(); // Return 404 if the customer is not found

            // Return 200 with the found customer
            return Ok(customer);
        }

        /// <summary>
        /// Creates a new customer.
        /// </summary>
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto customerDto)
        {
            var customer = await _customerService.CreateAsync(customerDto);

            // Return 201 with the created customer
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
        }

        /// <summary>
        /// Updates an existing customer.
        /// </summary>
        [HttpPatch("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateCustomer(Guid id, UpdateCustomerDto customerDto)
        {
            var customer = await _customerService.UpdateAsync(id, customerDto); // Return 404 if the customer was not found

            if (customer == null)
                return NotFound();

            // Return 200 with the updated customer
            return Ok(customer);
        }

        /// <summary>
        /// Deletes a customer by its ID.
        /// </summary>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            try
            {
                var isDeleted = await _customerService.DeleteAsync(id);

                // Return 404 if the customer wasn't found
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
