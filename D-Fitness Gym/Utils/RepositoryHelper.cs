using System.Reflection;

namespace D_Fitness_Gym.Utils
{
    public class RepositoryHelper
    {
        public static PropertyInfo GetPropertyInfo<TEntity>(string propertyName) where TEntity : class
        {
            // Use reflection to retrieve property information
            var propertyInfo = typeof(TEntity).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            
            return propertyInfo ?? throw new ArgumentException($"Property '{propertyName}' not found on entity {typeof(TEntity).Name}.");
        }
    }
}
