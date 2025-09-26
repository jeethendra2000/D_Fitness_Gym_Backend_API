using D_Fitness_Gym.CustomActionFilters;
using D_Fitness_Gym.Models.DTO.TransactionDto;
using D_Fitness_Gym.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace D_Fitness_Gym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController(ITransactionService transactionService) : ControllerBase
    {
        private readonly ITransactionService _transactionService = transactionService ?? throw new ArgumentNullException(nameof(transactionService));

        /// <summary>
        /// Retrieves all transactions.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllTransactions(string? filterOn, string? filterBy, string? sortOn, bool? isAscending, int? pageNo, int? pageSize, [FromQuery] string[]? includes)
        {
            //string[]? includes = ["Role"];
            var allUsers = await _transactionService.GetAllAsync(filterOn, filterBy, sortOn, isAscending, pageNo, pageSize, includes);

            if (allUsers == null || !allUsers.Data.Any())
                return NoContent();

            return Ok(allUsers);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetTransactionById(Guid id)
        {
            var transaction = await _transactionService.GetByIdAsync(id);

            if (transaction == null)
                return NotFound();

            return Ok(transaction);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateTransaction(CreateTransactionDto createTransactionDto)
        {
            var transaction = await _transactionService.CreateAsync(createTransactionDto);

            return CreatedAtAction(nameof(GetTransactionById), new { id = transaction.Id }, transaction);
        }

        [HttpPatch("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateTransaction(Guid id, UpdateTransactionDto updateTransactionDto)
        {
            var transaction = await _transactionService.UpdateAsync(id, updateTransactionDto);

            if (transaction == null)
                return NotFound();

            return Ok(transaction);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTransaction(Guid id)
        {
            try
            {
                var isDeleted = await _transactionService.DeleteAsync(id);
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
