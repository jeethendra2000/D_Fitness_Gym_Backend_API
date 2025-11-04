using AutoMapper;
using D_Fitness_Gym.Models.DTO.EmployeeDto;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Repositories.Interfaces;
using D_Fitness_Gym.Services.Interfaces;

namespace D_Fitness_Gym.Services
{
    public class EmployeeService : BaseService<Employee, CreateEmployeeDto, UpdateEmployeeDto, RetrieveEmployeeDto>, IEmployeeService
    {
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, ILogger<BaseService<Employee, CreateEmployeeDto, UpdateEmployeeDto, RetrieveEmployeeDto>> logger) : base(employeeRepository, mapper, logger)
        {
        }
    }
}
