using Microsoft.Extensions.Configuration;

namespace TransisterBatch.EntityFramework.Extensions
{
    public static class ConfigurationExtensions
    {
        public static DatabaseSettings GetDatabaseSettings(this IConfiguration configuration)
        {
            return configuration.GetSection(DatabaseSettings.SectionName).Get<DatabaseSettings>();
        }
    }
}
