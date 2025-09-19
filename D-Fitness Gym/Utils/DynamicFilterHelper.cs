using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace D_Fitness_Gym.Utils
{
    public class DynamicFilterHelper
    {
        public static IQueryable<TEntity> ApplyFiltering<TEntity>(IQueryable<TEntity> query, string? filterOn, string? filterBy) where TEntity : class
        {
            if (string.IsNullOrEmpty(filterOn) || string.IsNullOrEmpty(filterBy)) return query;

            // Validate if the 'filterOn' is a valid property of the entity
            var propertyInfo = RepositoryHelper.GetPropertyInfo<TEntity>(filterOn);

            // Dynamically Generate the filter expression based on the property type using Expression trees
            Expression<Func<TEntity, bool>> filterExpression = propertyInfo.PropertyType switch
            {
                Type t when t == typeof(string) => ExpressionBuilderHelper.BuildFilterExpression<TEntity>(filterOn, filterBy),
                Type t when t == typeof(int) => ExpressionBuilderHelper.BuildNumericFilterExpression<TEntity, int>(filterOn, filterBy),
                Type t when t == typeof(decimal) => ExpressionBuilderHelper.BuildNumericFilterExpression<TEntity, decimal>(filterOn, filterBy),
                Type t when t == typeof(DateTime) => ExpressionBuilderHelper.BuildDateTimeFilterExpression<TEntity>(filterOn, filterBy),
                Type t when t == typeof(bool) => ExpressionBuilderHelper.BuildBoolFilterExpression<TEntity>(filterOn, filterBy),
                _ => throw new InvalidOperationException($"Filtering by {propertyInfo.PropertyType} is not supported.")
            };

            // Apply the filter based on the property type
            query = query.Where(filterExpression);

            return query;
        }
    }
}
