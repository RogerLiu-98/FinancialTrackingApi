using FinancialTrackingApi.DataAccess.Contexts;
using FinancialTrackingApi.DataAccess.Entities;
using FinancialTrackingApi.DataAccess.Helpers;
using FinancialTrackingApi.DataAccess.Helpers.Interfaces;
using FinancialTrackingApi.DataAccess.Repositories;
using FinancialTrackingApi.DataAccess.Repositories.Interfaces;
using FinancialTrackingApi.Service;
using FinancialTrackingApi.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace FinancialTrackingApi
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("FinancialTracker");
            services.AddDbContext<FinancialTrackerContext>(o => o.UseSqlServer(connectionString));
        }

        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuration
            services.AddSingleton(configuration);

            // Helpers
            services.AddScoped<IUserProvider, UserProvider>();
            services.AddSingleton<TimeProvider, ConcreteTimeProvider>();

            // Services
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IUserService, UserService>();

            // Repositories
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.ConfigureIdentityOptions();
            })
            .AddEntityFrameworkStores<FinancialTrackerContext>()
            .AddDefaultTokenProviders();
        }

        private static void ConfigureIdentityOptions(this IdentityOptions options)
        {
            // Password settings
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = false;

            // Lockout settings
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            // User settings
            options.User.RequireUniqueEmail = true;

            // Sign-in settings
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(options =>
           {
               options.SaveToken = true;
               options.RequireHttpsMetadata = false;
               options.TokenValidationParameters = new TokenValidationParameters()
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidAudience = configuration["JWT:ValidAudience"],
                   ValidIssuer = configuration["JWT:ValidIssuer"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
               };
           });
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "FinancialTrackingApi", Version = "v1" });
            });
        }
    }
}
