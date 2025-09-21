namespace D_Fitness_Gym.Utils
{
    public class DynamicFilterHelper
    {
        public static IQueryable<TEntity> ApplyFiltering<TEntity>(IQueryable<TEntity> query, string? filterOn, string? filterBy) where TEntity : class
        {
            if (string.IsNullOrEmpty(filterOn) || string.IsNullOrEmpty(filterBy)) return query;

            // Dynamically Generate the filter expression based on the property type using Expression trees
            var filterExpression = ExpressionBuilderHelper.BuildFilterExpression<TEntity>(filterOn, filterBy);

            // Apply the filter based on the property type
            query = query.Where(filterExpression);

            return query;
        }
    }
}
