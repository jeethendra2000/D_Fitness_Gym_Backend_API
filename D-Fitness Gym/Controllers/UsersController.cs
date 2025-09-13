using D_Fitness_Gym.Data;
using Microsoft.AspNetCore.Mvc;

namespace D_Fitness_Gym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(ApplicationDbContext dbContext) : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var allUsers = _dbContext.Users.ToList();

            return Ok(allUsers);
        }
    }
}
