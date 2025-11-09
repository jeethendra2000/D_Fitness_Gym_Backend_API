using AutoMapper;
using D_Fitness_Gym.Models.DTO.CustomerDto;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Repositories.Interfaces;

namespace D_Fitness_Gym.Services
{
    public class CustomerService : BaseService<Customer, CreateCustomerDto, UpdateCustomerDto, RetrieveCustomerDto>
    {
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper, ILogger<BaseService<Customer, CreateCustomerDto, UpdateCustomerDto, RetrieveCustomerDto>> logger) : base(customerRepository, mapper, logger)
        {
        }
    }
}
