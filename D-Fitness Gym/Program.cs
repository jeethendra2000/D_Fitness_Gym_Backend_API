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
    .AddApplicationServices(builder.Configuration, builder.Environment)     // 2. Application layer (repositories, services, AutoMapper, etc.)
    .AddSwaggerDocumentation()                                              // 3. Swagger (depends only on base services)
    .AddCors(options =>
    {
        options.AddPolicy("AllowAll", policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
    })                                                                      // 4. Identity
    .AddCustomControllers();                                                // 5. API Controllers (depends only on base services)

// Build app
var app = builder.Build();

// Global Exception Handling (Middleware / Filter)
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() ||
    builder.Configuration.GetValue<bool>("EnableSwaggerInProd"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
