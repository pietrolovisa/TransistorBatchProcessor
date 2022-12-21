
namespace TransisterBatch.EntityFramework
{
    public class DatabaseSettings
    {
        public static string SectionName => "Database";
        public static string ConnectionName => nameof(ConnectionString);
        public string Provider { get; set; }
        public string ConnectionString { get; set; }
    }
}
