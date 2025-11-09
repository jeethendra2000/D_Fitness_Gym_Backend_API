using D_Fitness_Gym.Models.DTO.CustomerDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Services.Interfaces
{
    public interface ICustomerService : IBaseService<Customer, CreateCustomerDto, UpdateCustomerDto, RetrieveCustomerDto>
    {
    }
}
