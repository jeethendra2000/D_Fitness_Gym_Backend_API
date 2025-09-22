using AutoMapper;
using D_Fitness_Gym.Models.DTO.PaginationDto;
using D_Fitness_Gym.Repositories.Interfaces;
using D_Fitness_Gym.Services.Interfaces;

namespace D_Fitness_Gym.Services
{
    /// <summary>
    /// BaseService class provides a generic implementation for common CRUD operations.
    /// It can be inherited by other services to reduce code duplication.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity (e.g., Role, Account, etc.)</typeparam>
    /// <typeparam name="TCreateDto">DTO for creating a new entity</typeparam>
    /// <typeparam name="TUpdateDto">DTO for updating an existing entity</typeparam>
    /// <typeparam name="TRetrieveDto">DTO for retrieving entity data</typeparam>
    public abstract class BaseService<TEntity, TCreateDto, TUpdateDto, TRetrieveDto>(IBaseRepository<TEntity> baseRepository, IMapper mapper, ILogger<BaseService<TEntity, TCreateDto, TUpdateDto, TRetrieveDto>> logger) : 
        IBaseService<TEntity, TCreateDto, TUpdateDto, TRetrieveDto> where TEntity : class
    {
        // Repositories and Mapper are injected via Primary constructor and used throughout the service
        protected readonly IBaseRepository<TEntity> _baseRepository = baseRepository;
        protected readonly IMapper _mapper = mapper;
        protected readonly ILogger<BaseService<TEntity, TCreateDto, TUpdateDto, TRetrieveDto>> _logger = logger;

        #region CRUD Operations

        /// <summary>
        /// Retrieves all entities from the repository and maps them to the retrieval DTO.
        /// </summary>
        /// <returns>A collection of TRetrieveDto objects</returns>
        public virtual async Task<RetrievePaginationDto<TRetrieveDto>> GetAllAsync(string? filterOn, string? filterBy, string? sortOn, bool? isAscending, int? pageNo, int? pageSize, string[]? includes = null)
        {
            // Fetch all entities from the repository
            _logger.LogInformation($"Fetching all {typeof(TEntity).Name} entities.");

            if (includes != null && includes.Length != 0)
            {
                _logger.LogInformation($"Including navigation properties: {string.Join(", ", includes)}");
            }
            var response = await _baseRepository.GetAllAsync(filterOn, filterBy, sortOn, isAscending, pageNo, pageSize, includes);

            // Map the entities to the retrieval DTO and return
            _logger.LogInformation($"{response.Data.Count()} {typeof(TEntity).Name} entities fetched.");
            return _mapper.Map<RetrievePaginationDto<TRetrieveDto>>(response);
        }

        /// <summary>
        /// Retrieves a single entity by its unique ID and maps it to a retrieval DTO.
        /// Returns null if the entity is not found.
        /// </summary>
        /// <param name="id">The unique identifier of the entity</param>
        /// <returns>A TRetrieveDto object or null if not found</returns>
        public virtual async Task<TRetrieveDto?> GetByIdAsync(Guid id)
        {
            // Check if the record exists, if not return null
            _logger.LogInformation($"Fetching {typeof(TEntity).Name} with ID: {id}");
            var entity = await CheckIfRecordExistsAsync(id);
            if (entity == null)
            {
                _logger.LogWarning($"{typeof(TEntity).Name} with ID: {id} not found.");
                return default;
            }

            _logger.LogInformation($"{typeof(TEntity).Name} with ID: {id} fetched successfully.");
            return _mapper.Map<TRetrieveDto>(entity);
        }

        /// <summary>
        /// Creates a new entity from the provided DTO and returns the created entity as a retrieval DTO.
        /// </summary>
        /// <param name="dto">The DTO containing data to create a new entity</param>
        /// <returns>A TRetrieveDto representing the newly created entity</returns>
        public virtual async Task<TRetrieveDto> CreateAsync(TCreateDto dto)
        {
            // Map the incoming Create DTO to the corresponding entity
            _logger.LogInformation($"Creating a new {typeof(TEntity).Name}.");
            var entity = _mapper.Map<TEntity>(dto);

            // Create the entity in the repository and fetch the created entity
            var createdEntity = await _baseRepository.CreateAsync(entity);
            _logger.LogInformation($"{typeof(TEntity).Name} created with ID: {createdEntity.GetType().GetProperty("Id")?.GetValue(createdEntity)}.");

            // Map and return the created entity as a TRetrieveDto
            return _mapper.Map<TRetrieveDto>(createdEntity);
        }

        /// <summary>
        /// Updates an existing entity with the provided DTO and returns the updated entity as a retrieval DTO.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to update</param>
        /// <param name="dto">The DTO containing the updated data</param>
        /// <returns>A TRetrieveDto representing the updated entity or null if the entity was not found</returns>
        public virtual async Task<TRetrieveDto?> UpdateAsync(Guid id, TUpdateDto dto)
        {
            // Check if the entity exists before updating it
            _logger.LogInformation($"Updating {typeof(TEntity).Name} with ID: {id}");
            var existingRecord = await CheckIfRecordExistsAsync(id);
            if (existingRecord == null)
            {
                _logger.LogWarning($"{typeof(TEntity).Name} with ID: {id} not found for update.");
                return default;
            }
            // Map the update DTO fields into the existing entity
            _mapper.Map(dto, existingRecord);

            // Update the entity in the repository and return the updated entity
            var updatedRecord = await _baseRepository.UpdateAsync(existingRecord);
            _logger.LogInformation($"{typeof(TEntity).Name} with ID: {id} updated successfully.");

            // Map and return the updated entity as a TRetrieveDto
            return _mapper.Map<TRetrieveDto>(updatedRecord);

        }

        /// <summary>
        /// Deletes an existing entity by its ID. Returns false if the entity is not found, true if deleted successfully.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to delete</param>
        /// <returns>True if the entity was successfully deleted, false otherwise</returns>
        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            // Check if the entity exists before deleting it
            _logger.LogInformation($"Attempting to delete {typeof(TEntity).Name} with ID: {id}");
            var existingRecord = await CheckIfRecordExistsAsync(id);
            if (existingRecord == null)
            {
                _logger.LogWarning($"{typeof(TEntity).Name} with ID: {id} not found for deletion.");
                return false;
            }

            // Delete the entity from the repository and return the status
            var isDeleted = await _baseRepository.DeleteAsync(existingRecord);
            if (isDeleted)
            {
                _logger.LogInformation($"{typeof(TEntity).Name} with ID: {id} deleted successfully.");
            }
            else
            {
                _logger.LogWarning($"{typeof(TEntity).Name} with ID: {id} could not be deleted.");
            }

            return isDeleted;
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Checks if a record exists in the repository by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the entity</param>
        /// <returns>The entity if it exists, otherwise null</returns>
        protected virtual async Task<TEntity?> CheckIfRecordExistsAsync(Guid id) => await _baseRepository.GetByIdAsync(id);
        #endregion
    }
}
