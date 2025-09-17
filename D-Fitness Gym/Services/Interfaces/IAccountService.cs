using D_Fitness_Gym.Models.DTO.AccountDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Services.Interfaces
{
    public interface IAccountService : IBaseService<Account, CreateAccountDto, UpdateAccountDto, RetrieveAccountDto>
    {
        // Extra Business logic layer
    }
}
