using D_Fitness_Gym.Models.DTO.PaginationDto;
using Microsoft.EntityFrameworkCore;

namespace D_Fitness_Gym.Utils
{
    public class PaginationHelper
    {
        private const int DEFAULT_PAGE_SIZE = 10;
        private const int MAX_PAGE_SIZE = 100;

        /// <summary>
        /// Applies pagination to the query and returns the paged result.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities in the query.</typeparam>
        /// <param name="query">The query to paginate.</param>
        /// <param name="pageNo">The page number (optional, defaults to 1).</param>
        /// <param name="pageSize">The page size (optional, defaults to 10).</param>
        /// <returns>A paginated IQueryable<TEntity> with applied pagination.</returns>
        public async static Task<RetrievePaginationDto<TEntity>> ApplyPagination<TEntity>(IQueryable<TEntity> query, int? pageNo, int? pageSize)
        {
            // Validate and set default values for pageNo and pageSize
            pageNo ??= 1;
            pageSize = ValidatePageSize(pageSize.GetValueOrDefault(DEFAULT_PAGE_SIZE));

            // Calculate total count and pages
            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            
            // Check if there are previous or next pages
            bool hasPreviousPage = pageNo > 1;
            bool hasNextPage = pageNo < totalPages;

            // Apply pagination if valid page number and page size
            if (pageNo > 0 && pageSize.HasValue)
            {
                query = query.Skip((pageNo.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }
            // Fetch the data asynchronously for the current page
            var data = await query.ToListAsync();

            // Create metadata with the paged entities
            var metadata = new RetrievePaginationDto<TEntity>
            {
                Data = data, // Fetch the data for the current page
                TotalCount = totalCount,
                TotalPages = totalPages,
                CurrentPage = pageNo.Value,
                PageSize = pageSize.Value,
                HasPreviousPage = hasPreviousPage,
                HasNextPage = hasNextPage
            };
            return metadata; 
        }
        
        /// <summary>
         /// Validates the page size to ensure it is within valid bounds.
         /// </summary>
         /// <param name="pageSize">The requested page size.</param>
         /// <returns>A valid page size, constrained by the maximum allowed size.</returns>
        private static int ValidatePageSize(int pageSize)
        {
            if (pageSize <= 0)
            {
                return DEFAULT_PAGE_SIZE; // Default to 10 if pageSize is invalid
            }

            return pageSize > MAX_PAGE_SIZE ? MAX_PAGE_SIZE : pageSize;
        }

    }
}
