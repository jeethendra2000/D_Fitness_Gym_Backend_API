using D_Fitness_Gym.Models.DTO.AccountDto;
using D_Fitness_Gym.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace D_Fitness_Gym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController(IAccountService accountService) : ControllerBase
    {
        private readonly IAccountService _accountService = accountService;

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var allUsers = await _accountService.GetAllAsync();

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
        public async Task<IActionResult> CreateAccount(CreateAccountDto createAccountDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var account = await _accountService.CreateAsync(createAccountDto); 

            return CreatedAtAction(nameof(GetAccountById), new { id = account.Id }, account);
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> UpdateAccount(Guid id, UpdateAccountDto updateAccountDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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
