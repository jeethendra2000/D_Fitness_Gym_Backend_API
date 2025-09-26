﻿using D_Fitness_Gym.Mappings;
using D_Fitness_Gym.Repositories;
using D_Fitness_Gym.Repositories.Interfaces;
using D_Fitness_Gym.Services;
using D_Fitness_Gym.Services.Interfaces;

namespace D_Fitness_Gym.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config, IHostEnvironment env)
        {
            ////// Register AutoMapper with license and assembly scanning containing your profiles (Automapper-V15.0.1)
            ////builder.Services.AddAutoMapper(
            ////    cfg => cfg.LicenseKey = Environment.GetEnvironmentVariable("AUTO_MAPPER_LICENCE_KEY"),  // required
            ////    typeof(AccountProfile).Assembly                    // scan profiles
            ////);

            // Register AutoMapper with assembly scanning containing your profiles (Automapper-V14.0.0)
            services.AddAutoMapper(typeof(AccountProfile).Assembly);

            // Services
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<ITrainerService, TrainerService>();
            services.AddScoped<IMembershipService, MembershipService>();
            services.AddScoped<ITransactionService, TransactionService>();

            // Repositories
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<ITrainerRepository, TrainerRepository>();
            services.AddScoped<IMembershipRepository, MembershipRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();

            return services;

            //// Install Scrutor NuGet package "dotnet add package Scrutor" and then use this

            //// Register Repositories dynamically
            // services.Scan(scan => scan
            //    .FromAssemblyOf<IBaseRepository<object>>()  // pick assembly where repos live
            //    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
            //    .AsImplementedInterfaces()
            //    .WithScopedLifetime());

            //// Register Services dynamically
            // services.Scan(scan => scan
            //    .FromAssemblyOf<IBaseService<object, object, object, object>>()  // pick assembly where services live
            //    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
            //    .AsImplementedInterfaces()
            //    .WithScopedLifetime());

        }

    }
}
