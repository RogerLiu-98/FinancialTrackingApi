using FinancialTrackingApi.DataAccess.Contexts;
using FinancialTrackingApi.DataAccess.Helpers;
using FinancialTrackingApi.DataAccess.Helpers.Interfaces;
using FinancialTrackingApi.DataAccess.Repositories;
using FinancialTrackingApi.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            services.AddScoped<TimeProvider, ConcreteTimeProvider>();

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}
