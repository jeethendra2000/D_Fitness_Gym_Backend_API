using AutoMapper;
using D_Fitness_Gym.Models.DTO.CustomerDto;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Repositories.Interfaces;
using D_Fitness_Gym.Services.Interfaces;

namespace D_Fitness_Gym.Services
{
    public class CustomerService : BaseService<Customer, CreateCustomerDto, UpdateCustomerDto, RetrieveCustomerDto>, ICustomerService
    {
        private readonly IImageService _imageService;
        public CustomerService(ICustomerRepository customerRepository,IMapper mapper,ILogger<CustomerService> logger,IImageService imageService) : base(customerRepository, mapper, logger)
        {
            _imageService = imageService;
        }
        public override async Task<RetrieveCustomerDto> CreateAsync(CreateCustomerDto dto)
        {
            // Map DTO to Entity
            var customer = _mapper.Map<Customer>(dto);

            // Handle Image Upload: Pass the file from the DTO to the service 
            if (dto.ProfileImageFile != null)
            {
                customer.ProfileImageUrl = await _imageService.UploadImageAsync(dto.ProfileImageFile, "customers");
            }

            // Save to DB via Repository
            var createdCustomer = await _baseRepository.CreateAsync(customer);
            return _mapper.Map<RetrieveCustomerDto>(createdCustomer);
        }

        public override async Task<RetrieveCustomerDto?> UpdateAsync(Guid id, UpdateCustomerDto dto)
        {
            var existingCustomer = await CheckIfRecordExistsAsync(id);
            if (existingCustomer == null) return null;

            // Handle Image Update logic: If a new file is provided in the DTO
            if (dto.ProfileImageFile != null)
            {
                // Delete the current file
                _imageService.DeleteImage(existingCustomer.ProfileImageUrl);

                // Upload new image and update the string property in the Entity
                existingCustomer.ProfileImageUrl = await _imageService.UploadImageAsync(dto.ProfileImageFile, "customers");
            }

            // Map other fields from DTO to the existing entity
            _mapper.Map(dto, existingCustomer);

            // Save to DB via Repository
            var updatedCustomer = await _baseRepository.UpdateAsync(existingCustomer);
            return _mapper.Map<RetrieveCustomerDto>(updatedCustomer);
        }
        public override async Task<bool> DeleteAsync(Guid id)
        {
            var existingCustomer = await CheckIfRecordExistsAsync(id);
            if (existingCustomer != null && !string.IsNullOrEmpty(existingCustomer.ProfileImageUrl))
            {
                // Clean up the image file when the record is deleted
                _imageService.DeleteImage(existingCustomer.ProfileImageUrl);
            }

            return await base.DeleteAsync(id);
        }
    }
}
