using D_Fitness_Gym.CustomActionFilters;
using D_Fitness_Gym.Models.DTO.EmployeeDto;
using D_Fitness_Gym.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace D_Fitness_Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(IEmployeeService employeeService) : ControllerBase
    {
        private readonly IEmployeeService _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));

        /// <summary>
        /// Retrieves all employees.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees(string? filterOn, string? filterBy, string? sortOn, bool? isAscending, int? pageNo, int? pageSize)
        {
            var allEmployees = await _employeeService.GetAllAsync(filterOn, filterBy, sortOn, isAscending, pageNo, pageSize);

            if (allEmployees == null || !allEmployees.Data.Any())
                return NoContent(); // Return 204 if no employees are found

            // Return 200 with the employees
            return Ok(allEmployees);
        }

        /// <summary>
        /// Retrieves a employee by its ID.
        /// </summary>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            var employee = await _employeeService.GetByIdAsync(id);

            if (employee == null)
                return NotFound(); // Return 404 if the employee is not found

            // Return 200 with the found employee
            return Ok(employee);
        }

        /// <summary>
        /// Creates a new employee.
        /// </summary>
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateEmployee([FromForm] CreateEmployeeDto employeeDto)
        {
            var employee = await _employeeService.CreateAsync(employeeDto);

            // Return 201 with the created employee
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        [HttpPatch("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateEmployee(Guid id, [FromForm] UpdateEmployeeDto employeeDto)
        {
            var employee = await _employeeService.UpdateAsync(id, employeeDto); // Return 404 if the employee was not found

            if (employee == null)
                return NotFound();

            // Return 200 with the updated employee
            return Ok(employee);
        }

        /// <summary>
        /// Deletes a employee by its ID.
        /// </summary>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            try
            {
                var isDeleted = await _employeeService.DeleteAsync(id);

                // Return 404 if the employee wasn't found
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
