namespace D_Fitness_Gym.Services.Interfaces
{
    public interface IBaseService<TEntity, TCreateDto, TUpdateDto, TRetrieveDto> where TEntity : class
    {
        Task<IEnumerable<TRetrieveDto>> GetAllAsync();
        Task<TRetrieveDto?> GetByIdAsync(Guid id);
        Task<TRetrieveDto> CreateAsync(TCreateDto dto);
        Task<TRetrieveDto?> UpdateAsync(Guid id, TUpdateDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
