using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System;
using TransisterBatch.EntityFramework;
using TransisterBatch.EntityFramework.Extensions;
using TransistorBatchProcessor.Extensions;

namespace TransistorBatchProcessor
{
    internal static class Program
    {
        private const string OutputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] ({ThreadId}) {SourceContext:l} {Message:lj}{NewLine}{Exception}";

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

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();
            IServiceCollection services = new ServiceCollection();
            services.AddLogging(builder =>
            {
                LoggingSettings loggingSettings = _configuration.GetLoggingSettings();
                builder.AddSerilog(new LoggerConfiguration()
                    .MinimumLevel.Override("Microsoft", loggingSettings.MinMicrosoftLogEventLevel)
                    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", loggingSettings.MinEntityFrameworkCoreLogEventLevel)
                    .Enrich.FromLogContext()
                    .WriteTo.File("logs\\TransistorBatchProcessor.txt", loggingSettings.MinLogEventLevel, OutputTemplate)
                    .CreateLogger());
            });
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
            services.AddSingleton<UsbMonitorWorker>();
        }
    }
}