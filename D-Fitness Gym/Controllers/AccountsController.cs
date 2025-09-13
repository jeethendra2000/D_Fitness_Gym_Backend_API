using D_Fitness_Gym.Data;
using Microsoft.AspNetCore.Mvc;

namespace D_Fitness_Gym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController(ApplicationDbContext dbContext) : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        [HttpGet]
        public IActionResult GetAllAccounts()
        {
            var allUsers = _dbContext.Accounts.ToList();

            return Ok(allUsers);
        }
    }
}
