using D_Fitness_Gym.Models.DTO.PaginationDto;

namespace D_Fitness_Gym.Services.Interfaces
{
    public interface IBaseService<TEntity, TCreateDto, TUpdateDto, TRetrieveDto> where TEntity : class
    {
        Task<RetrievePaginationDto<TRetrieveDto>> GetAllAsync(string? filterOn, string?filterBy, string?sortOn, bool? isAscending, int?pageNo, int?pageSize, string[]? includes = null);
        Task<TRetrieveDto?> GetByIdAsync(Guid id);
        Task<TRetrieveDto> CreateAsync(TCreateDto dto);
        Task<TRetrieveDto?> UpdateAsync(Guid id, TUpdateDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
