using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransisterBatch.EntityFramework
{
    public static class DbProviderFactory
    {
        public static IDbProvider CreateDbProvider(DatabaseSettings configuration)
        {
            IDbProvider service = configuration.Provider switch
            {
                SqliteDbProvider.SQL_SERVER_PROVIDER_NAME => new SqliteDbProvider(configuration),
                _ => throw new Exception($"Database provider is invalid or does not exist [{configuration.Provider}]")
            };
            return service;
        }
    }
}
