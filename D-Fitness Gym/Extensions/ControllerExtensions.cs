using System.Text.Json.Serialization;

namespace D_Fitness_Gym.Extensions
{
    public static class ControllerExtensions
    {
        public static IMvcBuilder AddCustomControllers(this IServiceCollection services)
        {
            // Register Controller
            return services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                });
        }
    }
}
