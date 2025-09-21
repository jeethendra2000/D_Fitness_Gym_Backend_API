using System.Linq.Expressions;
using System.Reflection;

namespace D_Fitness_Gym.Utils
{
    public class ExpressionBuilderHelper
    {
        /// <summary>
        /// Dynamically builds an expression based on property type.
        /// </summary>
        public static Expression<Func<TEntity, bool>> BuildFilterExpression<TEntity>(string filterOn, string filterBy) where TEntity : class
        {
            // Use reflection to Validate if the 'filterOn' is a valid property of the entity
            var propertyInfo = RepositoryHelper.GetPropertyInfo<TEntity>(filterOn);

            var parameter = Expression.Parameter(typeof(TEntity), "e");
            var property = Expression.Property(parameter, filterOn);
            var filterValue = Expression.Constant(filterBy);

            // Create a filter expression based on the property type to build the correct filter expression
            Expression filterExpression = propertyInfo.PropertyType switch
            {
                Type t when t == typeof(string) => BuildStringFilterExpression(property, filterValue),
                Type t when t == typeof(int) => BuildNumericFilterExpression<int>(property, filterValue),
                Type t when t == typeof(decimal) => BuildNumericFilterExpression<decimal>(property, filterValue),
                Type t when t == typeof(DateTime) => BuildDateTimeFilterExpression<DateTime>(property, filterValue),
                Type t when t == typeof(DateOnly) => BuildDateTimeFilterExpression<DateOnly>(property, filterValue),
                Type t when t == typeof(TimeOnly) => BuildDateTimeFilterExpression<TimeOnly>(property, filterValue),
                Type t when t.IsEnum => BuildEnumFilterExpression(property, filterValue, propertyInfo.PropertyType),
                Type t when t == typeof(bool) => BuildBoolFilterExpression(property, filterValue),
                _ => throw new InvalidOperationException($"Filtering on {filterOn} is not supported.") // Default case for unsupported types
            };

            // Return the expression as a lambda
            return Expression.Lambda<Func<TEntity, bool>>(filterExpression, parameter);
        }

        #region Type-Specific Filter Expression Builders
        
        /// <summary>
        /// Build a filter expression for string properties.
        /// </summary>
        private static Expression BuildStringFilterExpression(MemberExpression property, ConstantExpression filterValue)
        {
            return Expression.Call(property, "Contains", null, Expression.Call(filterValue, "ToLower", null));
        }

        /// <summary>
        /// Build a numeric filter expression for int and decimal properties.
        /// </summary>
        private static Expression BuildNumericFilterExpression<TPropertyType>(MemberExpression property, ConstantExpression filterValue)
        {
            return Expression.Equal(property, Expression.Convert(filterValue, typeof(TPropertyType)));
        }

        /// <summary>
        /// Build a DateTime filter expression.
        /// </summary>
        private static Expression BuildDateTimeFilterExpression<TPropertyType>(MemberExpression property, ConstantExpression filterValue)
        {
            var filterValueParsed = Expression.Call(typeof(TPropertyType).GetMethod("Parse", [typeof(string)]), filterValue); // Assuming the filterValue is a string
            var filterValueConverted = Expression.Convert(filterValueParsed, typeof(TPropertyType));
            return Expression.Equal(property, filterValueConverted);
        }

        /// <summary>
        /// Build an enum filter expression.
        /// </summary>
        private static Expression BuildEnumFilterExpression(MemberExpression property, ConstantExpression filterValue, Type enumType)
        {
            // Convert the filter value to string and normalize case (e.g., to upper case)
            var filterValueString = Expression.Convert(filterValue, typeof(string));
            var filterValueToUpper = Expression.Call(filterValueString, "ToUpper", Type.EmptyTypes);

            // Get the Enum.Parse method (ignoring case)
            var enumParseMethod = typeof(Enum).GetMethod("Parse", [typeof(Type), typeof(string), typeof(bool)]);

            // Create a call to Enum.Parse
            var enumParseCall = Expression.Call(null, enumParseMethod, Expression.Constant(enumType), filterValueToUpper, Expression.Constant(true));

            // Compare the property value to the parsed enum value
            var equalityExpression = Expression.Equal(property, Expression.Convert(enumParseCall, property.Type));

            return equalityExpression;
        }
        /// <summary>
        /// Build a Boolean filter expression.
        /// </summary>
        private static Expression BuildBoolFilterExpression(MemberExpression property, ConstantExpression filterValue)
        {
            return Expression.Equal(property, Expression.Convert(filterValue, typeof(bool)));
        }

        #endregion
    }
}