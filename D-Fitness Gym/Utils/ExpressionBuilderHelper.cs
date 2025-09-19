using System.Linq.Expressions;

namespace D_Fitness_Gym.Utils
{
    public class ExpressionBuilderHelper
    {
        /// <summary>
        /// Dynamically builds an expression based on property type.
        /// </summary>
        public static Expression<Func<TEntity, bool>> BuildFilterExpression<TEntity>(string filterOn, string filterBy) where TEntity : class
        {
            var parameter = Expression.Parameter(typeof(TEntity), "e");
            var property = Expression.Property(parameter, filterOn);
            var filterValue = Expression.Constant(filterBy);

            // Use reflection to get the property info
            var propertyInfo = RepositoryHelper.GetPropertyInfo<TEntity>(filterOn);

            // Create a filter expression based on the property type
            // Switch on the property type to build the correct filter expression
            Expression filterExpression = propertyInfo.PropertyType switch
            {
                Type t when t == typeof(string) => BuildStringFilterExpression(property, filterValue),
                Type t when t == typeof(int) => BuildNumericFilterExpression<int>(property, filterValue),
                Type t when t == typeof(decimal) => BuildNumericFilterExpression<decimal>(property, filterValue),
                Type t when t == typeof(DateTime) => BuildDateTimeFilterExpression(property, filterValue),
                Type t when t == typeof(bool) => BuildBoolFilterExpression(property, filterValue),
                _ => BuildDefaultFilterExpression(property, filterValue) // Default case for unsupported types
            };

            // Return the expression as a lambda
            return Expression.Lambda<Func<TEntity, bool>>(filterExpression, parameter);
        }

        #region Type-Specific Filter Builders

        /// <summary>
        /// Build a filter expression for string properties.
        /// </summary>
        //public static Expression<Func<TEntity, bool>> BuildStringFilterExpression<TEntity, TProperty>(string filterOn, string filterBy) where TEntity : class
        //{
        //    (NEED FIX) 
        //    var parameter = Expression.Parameter(typeof(TEntity), "e");
        //    var property = Expression.Property(parameter, filterOn);
        //    var filterValue = Expression.Constant(Convert.ChangeType(filterBy, typeof(TProperty)));
        //    var equalExpression = Expression.Equal(property, filterValue);

        //    // For string properties, use Contains with case-insensitivity
        //    return Expression.Lambda<Func<TEntity, bool>>(equalExpression, parameter);
        //}

        /// <summary>
        /// Build a numeric filter expression for int and decimal properties.
        /// </summary>
        public static Expression<Func<TEntity, bool>> BuildNumericFilterExpression<TEntity, TProperty>(string filterOn, string filterBy) where TEntity : class
        {
            var parameter = Expression.Parameter(typeof(TEntity), "e");
            var property = Expression.Property(parameter, filterOn);
            var filterValue = Expression.Constant(Convert.ChangeType(filterBy, typeof(TProperty)));

            var equalExpression = Expression.Equal(property, filterValue);

            return Expression.Lambda<Func<TEntity, bool>>(equalExpression, parameter);
        }

        /// <summary>
        /// Build a DateTime filter expression.
        /// </summary>
        public static Expression<Func<TEntity, bool>> BuildDateTimeFilterExpression<TEntity>(string filterOn, string filterBy) where TEntity : class
        {
            var parameter = Expression.Parameter(typeof(TEntity), "e");
            var property = Expression.Property(parameter, filterOn);
            var filterValue = Expression.Constant(DateTime.Parse(filterBy));

            var equalExpression = Expression.Equal(property, filterValue);

            return Expression.Lambda<Func<TEntity, bool>>(equalExpression, parameter);
        }

        /// <summary>
        /// Build a Boolean filter expression.
        /// </summary>
        public static Expression<Func<TEntity, bool>> BuildBoolFilterExpression<TEntity>(string filterOn, string filterBy) where TEntity : class
        {
            var parameter = Expression.Parameter(typeof(TEntity), "e");
            var property = Expression.Property(parameter, filterOn);
            var filterValue = Expression.Constant(Convert.ToBoolean(filterBy));

            var equalExpression = Expression.Equal(property, filterValue);

            return Expression.Lambda<Func<TEntity, bool>>(equalExpression, parameter);
        }

        private static Expression BuildStringFilterExpression(MemberExpression property, ConstantExpression filterValue)
        {
            // For string properties, use Contains with case-insensitivity
            return Expression.Call(property, "Contains", null, Expression.Call(filterValue, "ToLower", null));
        }

        private static Expression BuildNumericFilterExpression<TProperty>(MemberExpression property, ConstantExpression filterValue)
        {
            // For numeric properties (int, decimal), perform equality check
            return Expression.Equal(property, Expression.Convert(filterValue, typeof(TProperty)));
        }

        private static Expression BuildDateTimeFilterExpression(MemberExpression property, ConstantExpression filterValue)
        {
            // For DateTime properties, parse and compare
            return Expression.Equal(property, Expression.Convert(filterValue, typeof(DateTime)));
        }

        private static Expression BuildBoolFilterExpression(MemberExpression property, ConstantExpression filterValue)
        {
            // For Boolean properties, perform equality check
            return Expression.Equal(property, Expression.Convert(filterValue, typeof(bool)));
        }

        private static Expression BuildDefaultFilterExpression(MemberExpression property, ConstantExpression filterValue)
        {
            // For unsupported types, convert to string and use Contains
            var toStringMethod = property.Type.GetMethod("ToString");
            var toStringCall = Expression.Call(property, toStringMethod);
            return Expression.Call(toStringCall, "Contains", null, Expression.Call(filterValue, "ToLower", null));
        }

        #endregion
    }
}