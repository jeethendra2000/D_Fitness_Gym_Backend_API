using AutoMapper;
using D_Fitness_Gym.Models.DTO.EmployeeDto;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Repositories.Interfaces;
using D_Fitness_Gym.Services.Interfaces;

namespace D_Fitness_Gym.Services
{
    public class EmployeeService : BaseService<Employee, CreateEmployeeDto, UpdateEmployeeDto, RetrieveEmployeeDto>, IEmployeeService
    {
        private readonly IImageService _imageService;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, ILogger<EmployeeService> logger, IImageService imageService) : base(employeeRepository, mapper, logger)
        {
            _imageService = imageService;
        }
        public override async Task<RetrieveEmployeeDto> CreateAsync(CreateEmployeeDto dto)
        {
            // Map DTO to Entity
            var employee = _mapper.Map<Employee>(dto);

            // Handle Image Upload: Pass the file from the DTO to the service 
            if (dto.ProfileImageFile != null)
            {
                employee.ProfileImageUrl = await _imageService.UploadImageAsync(dto.ProfileImageFile, "employees");
            }

            // Save to DB via Repository
            var createdEmployee = await _baseRepository.CreateAsync(employee);
            return _mapper.Map<RetrieveEmployeeDto>(createdEmployee);
        }

        public override async Task<RetrieveEmployeeDto?> UpdateAsync(Guid id, UpdateEmployeeDto dto)
        {
            var existingEmployee = await CheckIfRecordExistsAsync(id);
            if (existingEmployee == null) return null;

            // Handle Image Update logic: If a new file is provided in the DTO
            if (dto.ProfileImageFile != null)
            {
                // Delete the current file
                _imageService.DeleteImage(existingEmployee.ProfileImageUrl);

                // Upload new image and update the string property in the Entity
                existingEmployee.ProfileImageUrl = await _imageService.UploadImageAsync(dto.ProfileImageFile, "employees");
            }

            // Map other fields from DTO to the existing entity
            _mapper.Map(dto, existingEmployee);

            // Save to DB via Repository
            var updatedEmployee = await _baseRepository.UpdateAsync(existingEmployee);
            return _mapper.Map<RetrieveEmployeeDto>(updatedEmployee);
        }
        public override async Task<bool> DeleteAsync(Guid id)
        {
            var existingEmployee = await CheckIfRecordExistsAsync(id);
            if (existingEmployee != null && !string.IsNullOrEmpty(existingEmployee.ProfileImageUrl))
            {
                // Clean up the image file when the record is deleted
                _imageService.DeleteImage(existingEmployee.ProfileImageUrl);
            }

            return await base.DeleteAsync(id);
        }
    }
}
