using D_Fitness_Gym.Extensions;
using D_Fitness_Gym.Middleware;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// Load .env variables for local development
builder.Configuration.AddEnvironmentVariables();
if (builder.Environment.IsDevelopment())
{
    Env.Load(); // loads variables from .env
}

// Register all services (moved to Extensions folder)
builder.Services
    .AddDatabaseConfigurations(builder.Configuration, builder.Environment)  // 1. Database (foundation of the app)
    .AddIdentityAndConfigurations(builder.Configuration)                    // 2. Identity 
    .AddApplicationServices(builder.Configuration, builder.Environment)     // 3. Application layer (repositories, services, AutoMapper, etc.)
    .AddJwtAuthentication(builder.Configuration)                            // 4. Authentication / Authorization (depends on Identity)
    .AddSwaggerDocumentation()                                              // 5. Swagger (depends only on base services)
    .AddCustomControllers();                                                // 6. API Controllers (depends only on base services)

// Build app
var app = builder.Build();

// Global Exception Handling (Middleware / Filter)
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
