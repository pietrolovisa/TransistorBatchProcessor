using Microsoft.Extensions.DependencyInjection;
using TransisterBatch.EntityFramework;
using TransisterBatch.EntityFramework.Extensions;

namespace TransistorBatchProcessor
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            using ServiceProvider serviceProvider = services.BuildServiceProvider();
            //Form1 form = serviceProvider.GetRequiredService<Form1>();
            TransistorBatchForm form = serviceProvider.GetRequiredService<TransistorBatchForm>();
            Application.Run(form);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            DatabaseSettings configuration = new DatabaseSettings
            {
                Provider = "Sqlite",
                ConnectionString = "Data Source=C:\\Users\\plovisa\\source\\repos\\TransistorBatchProcessor\\TransistorBatchProcessor\\Database\\TransistorBatch.db;Cache=Shared"
            };
            services.SetupDatabase<EFContext>(configuration);
            services.AddScoped<Form1>();
            services.AddScoped<TransistorBatchForm>();
        }
    }
}