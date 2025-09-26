using Microsoft.AspNetCore.Identity;

namespace D_Fitness_Gym.Repositories.Interfaces
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
