using D_Fitness_Gym.CustomActionFilters;
using D_Fitness_Gym.Models.DTO.AccountDto;
using D_Fitness_Gym.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace D_Fitness_Gym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController(IAccountService accountService) : ControllerBase
    {
        private readonly IAccountService _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));

        /// <summary>
        /// Retrieves all accounts.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAccounts(string? filterOn, string? filterBy, string? sortOn, bool? isAscending, int? pageNo, int? pageSize, [FromQuery] string[]? includes)
        {
            //string[]? includes = ["Role"];
            var allUsers = await _accountService.GetAllAsync(filterOn, filterBy, sortOn, isAscending, pageNo, pageSize, includes);

            if(allUsers == null || !allUsers.Data.Any()) 
                   return NoContent();

            return Ok(allUsers);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAccountById(Guid id)
        {
            var account = await _accountService.GetByIdAsync(id);

            if (account == null)
                return NotFound();
            
            return Ok(account);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateAccount(CreateAccountDto createAccountDto)
        {
            var account = await _accountService.CreateAsync(createAccountDto); 

            return CreatedAtAction(nameof(GetAccountById), new { id = account.Id }, account);
        }

        [HttpPatch("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateAccount(Guid id, UpdateAccountDto updateAccountDto)
        {
            var account = await _accountService.UpdateAsync(id, updateAccountDto);

            if (account == null)
                return NotFound();

            return Ok(account);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAccount(Guid id)
        {
            try
            {
                var isDeleted = await _accountService.DeleteAsync(id);
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
