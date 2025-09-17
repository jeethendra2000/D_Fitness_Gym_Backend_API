using D_Fitness_Gym.Data;
using D_Fitness_Gym.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace D_Fitness_Gym.Repositories
{
    /// <summary>
    /// BaseRepository class provides generic CRUD operations for entities.
    /// This is intended to be used by other repositories as a base class to reduce code duplication.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity (e.g., Role, Account, etc.)</typeparam>
    public class BaseRepository<TEntity>(ApplicationDbContext dbContext) : IBaseRepository<TEntity> where TEntity : class
    {
        // Initializes the ApplicationDbContext to interact with the database, Throw an exception if the dbContext is null to ensure valid initialization
        protected readonly ApplicationDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        /// <summary>
        ///  Retrieves all records of corresponding Entity Type.
        /// </summary>
        /// <returns>A list of all records of corresponding Entity Type</returns>
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbContext.Set<TEntity>().ToListAsync();

        /// <summary>
        /// Retrieves a single entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>The entity if found; otherwise, null.</returns>
        public virtual async Task<TEntity?> GetByIdAsync(Guid id) => await _dbContext.Set<TEntity>().FindAsync(id);

        /// <summary>
        /// Creates a new entity and saves it to the database.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <returns>The created entity.</returns>
        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            // Adds the new entity to the DbSet for the corresponding entity type.
            _dbContext.Set<TEntity>().Add(entity);

            // Saves the changes to the database asynchronously.
            await _dbContext.SaveChangesAsync();

            // Returns the created entity (now with an ID or any other database-generated values).
            return entity;
        }

        /// <summary>
        /// Updates an existing entity in the database.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        public virtual async Task<TEntity?> UpdateAsync(TEntity entity)
        {
            // Updates the entity in the DbSet for the corresponding entity type.
            _dbContext.Set<TEntity>().Update(entity);

            // Saves the changes to the database asynchronously.
            await _dbContext.SaveChangesAsync();

            // Returns the updated entity.
            return entity;

        }

        /// <summary>
        /// Deletes an entity from the database.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        /// <returns>True if the entity was successfully deleted; otherwise, false.</returns>
        public virtual async Task<bool> DeleteAsync(TEntity entity)
        {
            // Removes the entity from the DbSet for the corresponding entity type.
            _dbContext.Set<TEntity>().Remove(entity);

            // Saves the changes to the database asynchronously.
            await _dbContext.SaveChangesAsync();

            // Returns true if the entity was successfully deleted (i.e., changes were saved).
            return true;
        }
    }
}
