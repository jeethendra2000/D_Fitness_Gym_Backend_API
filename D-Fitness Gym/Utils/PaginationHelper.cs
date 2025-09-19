namespace D_Fitness_Gym.Utils
{
    public class PaginationHelper
    {
        public static IQueryable<TEntity> ApplyPagination<TEntity>(IQueryable<TEntity> query, int? pageNo, int? pageSize)
        {
            // Validate pageNo and default to 1 if it's invalid (<= 0)
            if (pageNo.HasValue && pageNo.Value < 1)
            {
                pageNo = 1;
            }

            // Validate pageSize and default to a sensible value if it's invalid (<= 0 or null)
            if (!pageSize.HasValue || pageSize.Value < 1)
            {
                pageSize = 1000; // Default to 1000 if no pageSize is provided or it's invalid
            }

            if (pageNo.HasValue && pageSize.HasValue)
            {
                query = query.Skip((pageNo.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }

            return query;
        }

    }
}
