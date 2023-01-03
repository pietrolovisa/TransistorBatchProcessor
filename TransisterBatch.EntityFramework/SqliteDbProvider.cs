using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransisterBatch.EntityFramework.Extensions;

namespace TransisterBatch.EntityFramework
{
    public class SqliteDbProvider : IDbProvider
    {
        public const string SQL_SERVER_PROVIDER_NAME = "Sqlite";
        public const string RESOURCE_BROKER_MANAGEMENT_SCHEMA = "ResourceBrokerManagement";
        public const string MIGRATIONS_TABLE_NAME = "Migration";

        private readonly IConfiguration _configuration;

        public SqliteDbProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SetupServices<TDbContext>(IServiceCollection services) where TDbContext : DbContext
        {
            DatabaseSettings databaseSettings = _configuration.GetDatabaseSettings();
            services.AddEntityFrameworkSqlite().AddDbContext<TDbContext>((sp, options) =>
            {
                options.UseSqlite(databaseSettings.ConnectionString, optionsAction =>
                    optionsAction.MigrationsHistoryTable(MIGRATIONS_TABLE_NAME)
                );
                options.UseInternalServiceProvider(sp);
            });
        }
    }
}
