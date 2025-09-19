namespace D_Fitness_Gym.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync(string? filterOn, string? filterBy, string? sortOn, bool? isAscending, int? pageNo, int? pageSize);
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity?> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
    }
    
}
