using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TransisterBatch.EntityFramework.Repository;
using Microsoft.Extensions.Configuration;

namespace TransisterBatch.EntityFramework.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection SetupDatabase<TDbContext>(this IServiceCollection services, IConfiguration configuration) where TDbContext : DbContext
        {
            IDbProvider dbService = DbProviderFactory.CreateDbProvider(configuration);
            dbService.SetupServices<TDbContext>(services);
            services.AddScoped<IBatchTypeRepository, BatchTypeRepository>();
            services.AddScoped<IBatchRepository, BatchRepository>();
            services.AddScoped<ITransistorRepository, TransistorRepository>();
            return services;
        }

        public static void ApplyDBMigrations<TDbContext>(this IServiceCollection services, IConfiguration configuration) where TDbContext : DbContext
        {
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            TDbContext dbContext = serviceProvider.GetService<TDbContext>();
            using IServiceScope serviceScope = serviceProvider.GetService<IServiceScopeFactory>().CreateScope();
            dbContext.Database.Migrate();
        }
    }
}
