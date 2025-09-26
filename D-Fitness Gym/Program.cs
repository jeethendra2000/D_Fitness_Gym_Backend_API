using D_Fitness_Gym.Data;
using D_Fitness_Gym.Mappings;
using D_Fitness_Gym.Middleware;
using D_Fitness_Gym.Repositories;
using D_Fitness_Gym.Repositories.Interfaces;
using D_Fitness_Gym.Services;
using D_Fitness_Gym.Services.Interfaces;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

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

// Register Controller
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

// Register Account Services & Repositories (Scoped = one per request)
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();

// Register Role Services & Repositories
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

// Register User Services & Repositories
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Register Subscription Services & Repositories
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

// Register Trainer Services & Repositories
builder.Services.AddScoped<ITrainerService, TrainerService>();
builder.Services.AddScoped<ITrainerRepository, TrainerRepository>();

// Register Membership Services & Repositories
builder.Services.AddScoped<IMembershipService, MembershipService>();
builder.Services.AddScoped<IMembershipRepository, MembershipRepository>();

// Register Transaction Services & Repositories
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

// Register Token Repository
builder.Services.AddScoped<ITokenRepository, TokenRepository>();

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
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "D-Fitness API", Version = "v1" });
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = JwtBearerDefaults.AuthenticationScheme
    });

    // Add security to Swagger
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                },
                Scheme = "Oauth2",
                Name = JwtBearerDefaults.AuthenticationScheme,
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

// Configure EF Core with the correct connection string based on the environment (appsettings.json or .env)
var connectionString = builder.Environment.IsDevelopment() ? builder.Configuration.GetConnectionString("DefaultSQLConnection") : Environment.GetEnvironmentVariable("PUBLIC_DB_CONNECTION_STRING");
var authConnectionString = builder.Environment.IsDevelopment() ? builder.Configuration.GetConnectionString("DefaultAuthSQLConnection") : Environment.GetEnvironmentVariable("PUBLIC_AUTH_DB_CONNECTION_STRING");

// Register DB_Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<DFitnessAuthDBContext>(options =>
    options.UseSqlServer(authConnectionString));

//Register AutoMapper with assembly scanning containing your profiles (Automapper-V14.0.0)
builder.Services.AddAutoMapper(typeof(AccountProfile).Assembly);

// Inject Identity roles, token provider 
builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("DFitness")
    .AddEntityFrameworkStores<DFitnessAuthDBContext>()
    .AddDefaultTokenProviders();

// Configure Identity password pattern
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequireNonAlphanumeric = false;
});

// Add Authentication and JWT Bearer token along with the parameters
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
    {
        AuthenticationType = "Jwt",
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        //ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidAudiences = new[] { builder.Configuration["Jwt:Audience"] },
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    });

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
