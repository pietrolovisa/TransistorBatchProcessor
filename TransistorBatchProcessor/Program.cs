using Microsoft.Extensions.DependencyInjection;
using TransisterBatch.EntityFramework;
using TransisterBatch.EntityFramework.Extensions;
using TransisterBatch.EntityFramework.Repository;

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
            //// To customize application configuration such as set high DPI settings or default font,
            //// see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                Form1 form1 = serviceProvider.GetRequiredService<Form1>();
                Application.Run(form1);
            }
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
        }
    }
}