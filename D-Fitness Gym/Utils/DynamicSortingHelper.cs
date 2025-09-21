using Microsoft.EntityFrameworkCore;

namespace D_Fitness_Gym.Utils
{
    public class DynamicSortingHelper
    {
        public static IQueryable<TEntity> ApplySorting<TEntity>(IQueryable<TEntity> query, string? sortOn, bool? isAscending) where TEntity : class
        {
            if (string.IsNullOrEmpty(sortOn)) return query;

            // Validate if the 'filterOn' is a valid property of the entity
            var propertyInfo = RepositoryHelper.GetPropertyInfo<TEntity>(sortOn);

            // Sort based on the property type
            return query = isAscending.HasValue && isAscending.Value
                    ? query.OrderBy(e => EF.Property<object>(e, propertyInfo.Name))
                    : query.OrderByDescending(e => EF.Property<object>(e, propertyInfo.Name)); ;
        }
    }
}
