using AutoMapper;
using D_Fitness_Gym.Models.DTO.AccountDto;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Repositories;
using D_Fitness_Gym.Repositories.Interfaces;
using D_Fitness_Gym.Services.Interfaces;

namespace D_Fitness_Gym.Services
{
    public class AccountService(IAccountRepository accountRepository, IMapper mapper, ILogger<AccountService> logger) :
        BaseService<Account, CreateAccountDto, UpdateAccountDto, RetrieveAccountDto>(accountRepository, mapper, logger), IAccountService
    {
        
    }
}
