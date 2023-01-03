using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TransisterBatch.EntityFramework;
using TransisterBatch.EntityFramework.Extensions;

namespace TransistorBatchProcessor
{
    internal static class Program
    {
        public static IConfiguration _configuration;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();

            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            using ServiceProvider serviceProvider = services.BuildServiceProvider();
            //Form1 form = serviceProvider.GetRequiredService<Form1>();
            TransistorBatchForm form = serviceProvider.GetRequiredService<TransistorBatchForm>();
            Application.Run(form);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.SetupDatabase<EFContext>(_configuration);
            services.AddScoped<Form1>();
            services.AddScoped<TransistorBatchForm>();
        }
    }
}