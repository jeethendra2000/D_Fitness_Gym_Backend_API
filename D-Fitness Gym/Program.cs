using D_Fitness_Gym.Data;
using D_Fitness_Gym.Mappings;
using D_Fitness_Gym.Middleware;
using D_Fitness_Gym.Repositories;
using D_Fitness_Gym.Repositories.Interfaces;
using D_Fitness_Gym.Services;
using D_Fitness_Gym.Services.Interfaces;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables in development from .env
if (builder.Environment.IsDevelopment())
{
    Env.Load(); // loads variables from .env
}

//// Register AutoMapper with license and assembly scanning containing your profiles (Automapper-V15.0.1)
//builder.Services.AddAutoMapper(
//    cfg => cfg.LicenseKey = Environment.GetEnvironmentVariable("AUTO_MAPPER_LICENCE_KEY"),  // required
//    typeof(AccountProfile).Assembly                    // scan profiles
//);

//Register AutoMapper with assembly scanning containing your profiles (Automapper-V14.0.0)
builder.Services.AddAutoMapper(typeof(AccountProfile).Assembly);


// Register Controller
builder.Services.AddControllers();

// Register Repositories
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

// Register Services
builder.Services.AddScoped<IAccountService, AccountService>();

// Register Services
builder.Services.AddScoped<IRoleService, RoleService>();

// Register Repositories (Scoped = one per request)
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

//// Register Repositories dynamically
///Install Scrutor NuGet package and then use this
//builder.Services.Scan(scan => scan
//    .FromAssemblyOf<IBaseRepository<object>>()  // pick assembly where repos live
//    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
//    .AsImplementedInterfaces()
//    .WithScopedLifetime());

//// Register Services dynamically
//builder.Services.Scan(scan => scan
//    .FromAssemblyOf<IBaseService<object, object, object, object>>()  // pick assembly where services live
//    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
//    .AsImplementedInterfaces()
//    .WithScopedLifetime());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure EF Core with the correct connection string based on the environment (appsettings.json or .env)
var connectionString = builder.Environment.IsDevelopment() ? builder.Configuration.GetConnectionString("DefaultSQLConnection") : Environment.GetEnvironmentVariable("PUBLIC_DB_CONNECTION_STRING");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Global Exception Handling (Middleware / Filter)
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
