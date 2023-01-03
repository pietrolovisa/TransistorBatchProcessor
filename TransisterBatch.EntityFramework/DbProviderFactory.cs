using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransisterBatch.EntityFramework.Extensions;

namespace TransisterBatch.EntityFramework
{
    public static class DbProviderFactory
    {
        public static IDbProvider CreateDbProvider(IConfiguration configuration)
        {
            DatabaseSettings databaseSettings = configuration.GetDatabaseSettings();
            IDbProvider service = databaseSettings.Provider switch
            {
                SqliteDbProvider.SQL_SERVER_PROVIDER_NAME => new SqliteDbProvider(configuration),
                _ => throw new Exception($"Database provider is invalid or does not exist [{databaseSettings.Provider}]")
            };
            return service;
        }
    }
}
