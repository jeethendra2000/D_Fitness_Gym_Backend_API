using D_Fitness_Gym.Data;
using Microsoft.EntityFrameworkCore;

namespace D_Fitness_Gym.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddDatabaseConfigurations(this IServiceCollection services, IConfiguration config, IHostEnvironment env)
        {
            // Configure EF Core with the correct connection string based on the environment (appsettings.json or .env)
            var connectionString = config.GetConnectionString("DefaultSQLConnection");

            // Register DBContext
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            return services;
        }

    }
}
