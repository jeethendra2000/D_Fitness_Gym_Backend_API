using D_Fitness_Gym.Models.DTO.TransactionDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Services.Interfaces
{
    public interface ITransactionService : IBaseService<Transaction, CreateTransactionDto, UpdateTransactionDto, RetrieveTransactionDto>
    {
        // Transaction-specific methods can be added here

    }
}
