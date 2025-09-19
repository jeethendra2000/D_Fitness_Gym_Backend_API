namespace D_Fitness_Gym.Middleware
{
    public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (InvalidOperationException ex)
            {
                // Log the exception details
                _logger.LogError(ex, "InvalidOperation exception");

                // Set the response code to 400 (Bad Request)
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";

                // Create an error response model with the error details
                var errorDetails = new
                {
                    error = ex.Message,
                };

                // Serialize the error response to JSON and return it
                var result = System.Text.Json.JsonSerializer.Serialize(errorDetails);

                // Write the result to the response body
                await context.Response.WriteAsync(result);
            }
            catch (ArgumentException ex)
            {
                // Log the exception details
                _logger.LogError(ex, "Argument exception");

                // Set the response code to 400 (Bad Request)
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";

                // Create an error response model with the error details
                var errorDetails = new
                {
                    error = ex.Message,
                };

                // Serialize the error response to JSON and return it
                var result = System.Text.Json.JsonSerializer.Serialize(errorDetails);

                // Write the result to the response body
                await context.Response.WriteAsync(result);
            }
            catch (Exception ex)
            {
                // Log the exception details
                _logger.LogError(ex, "Unhandled exception");

                // Set the response code to 500 (Internal Server Error)
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                // Create a error response model with the error details
                var errorDetails = new
                {
                    error = "An unexpected error occurred.",
                    details = ex.Message, // Expose the error message
                    innerException = ex.InnerException?.Message // Include inner exception details (if any)
                };

                // Serialize the error response to JSON and return it
                var result = System.Text.Json.JsonSerializer.Serialize(errorDetails);

                // Write the result to the response body
                await context.Response.WriteAsync(result);
            }
        }
    }
}