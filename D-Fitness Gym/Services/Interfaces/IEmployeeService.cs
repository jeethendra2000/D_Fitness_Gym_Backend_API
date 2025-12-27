using D_Fitness_Gym.Models.DTO.EmployeeDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Services.Interfaces
{
    public interface IEmployeeService : IBaseService<Employee, CreateEmployeeDto, UpdateEmployeeDto, RetrieveEmployeeDto>
    {

    }
}
