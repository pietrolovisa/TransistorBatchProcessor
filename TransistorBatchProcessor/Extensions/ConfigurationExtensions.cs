using System;
using Microsoft.Extensions.Configuration;

namespace TransistorBatchProcessor.Extensions
{
    public static class ConfigurationExtensions
    {
        public static LoggingSettings GetLoggingSettings(this IConfiguration configuration)
        {
            return configuration.GetSection(LoggingSettings.SectionName).Get<LoggingSettings>();
        }
    }

    public class LoggingSettings
    {
        public static string SectionName => "Logging";
        public string LogEventLevel { get; set; }
        public string MicrosoftLogEventLevel { get; set; }
        public string EntityFrameworkCoreLogEventLevel { get; set; }

        public Serilog.Events.LogEventLevel MinLogEventLevel =>
            Enum.TryParse<Serilog.Events.LogEventLevel>(LogEventLevel, out Serilog.Events.LogEventLevel minLogEventLevel) ?
            minLogEventLevel : Serilog.Events.LogEventLevel.Information;
        public Serilog.Events.LogEventLevel MinMicrosoftLogEventLevel =>
            Enum.TryParse<Serilog.Events.LogEventLevel>(MicrosoftLogEventLevel, out Serilog.Events.LogEventLevel minLogEventLevel) ?
            minLogEventLevel : Serilog.Events.LogEventLevel.Information;
        public Serilog.Events.LogEventLevel MinEntityFrameworkCoreLogEventLevel =>
            Enum.TryParse<Serilog.Events.LogEventLevel>(EntityFrameworkCoreLogEventLevel, out Serilog.Events.LogEventLevel minLogEventLevel) ?
            minLogEventLevel : Serilog.Events.LogEventLevel.Information;
    }
}
