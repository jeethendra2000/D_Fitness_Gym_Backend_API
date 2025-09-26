using D_Fitness_Gym.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace D_Fitness_Gym.Extensions
{
    public static class AuthenticationExtensions
    {
        /// <summary>
        /// Configures ASP.NET Core Identity with EF Core stores and custom password options.
        /// </summary>
        public static IServiceCollection AddIdentityAndConfigurations(this IServiceCollection services, IConfiguration config)
        {
            // Identity setup ( Inject Identity roles, token provider etc.,)
            services.AddIdentityCore<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("DFitness")
                .AddEntityFrameworkStores<DFitnessAuthDBContext>()
                .AddDefaultTokenProviders();

            // Password policy configuration
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredUniqueChars = 1;
            });

            return services;
        }

        /// <summary>
        /// Configures JWT Bearer authentication with settings from app configuration.
        /// </summary>
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration config)
        {
            var key = Encoding.UTF8.GetBytes(config["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key not configured"));

            // Add Authentication and JWT Bearer token along with the parameters
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        AuthenticationType = "Jwt",
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = config["Jwt:Issuer"],
                        ValidAudiences = [config["Jwt:Audience"]],
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };
                });

            return services;
        }

    }
}
