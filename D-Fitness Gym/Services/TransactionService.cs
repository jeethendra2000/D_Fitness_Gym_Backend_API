using AutoMapper;
using D_Fitness_Gym.Models.DTO.TransactionDto;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Repositories.Interfaces;
using D_Fitness_Gym.Services.Interfaces;

namespace D_Fitness_Gym.Services
{
    public class TransactionService : BaseService<Transaction, CreateTransactionDto, UpdateTransactionDto, RetrieveTransactionDto>, ITransactionService
    {
        public TransactionService(ITransactionRepository transactionRepository, IMapper mapper, ILogger<BaseService<Transaction, CreateTransactionDto, UpdateTransactionDto, RetrieveTransactionDto>> logger) : base(transactionRepository, mapper, logger)
        {
        }
        // Transaction-specific methods can be added here

    }
}
