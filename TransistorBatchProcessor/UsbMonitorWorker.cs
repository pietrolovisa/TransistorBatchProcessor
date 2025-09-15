using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Management;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace TransistorBatchProcessor
{
    public class UsbMonitorWorker(ILogger<UsbMonitorWorker> logger) : BackgroundService
    {
        private ManagementEventWatcher _watcher;
        private readonly ILogger<UsbMonitorWorker> _logger = logger;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"Starting {nameof(UsbMonitorWorker)}...");
            var query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2");
            _watcher = new ManagementEventWatcher(query);
            _watcher.EventArrived += (s, e) =>
            {
                //DeviceConnected?.Invoke("A USB device was connected.");
                _logger.LogInformation($"A USB device was connected. {e}");
                IsTargetDeviceConnected();
            };
            _watcher.Start();
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(2), stoppingToken);
            }
        }

        /// <summary>
        /// B30FC952-F4AD-409C-88A2-0898085A21B1 ?????
        /// </summary>
        /// <returns></returns>
        private bool IsTargetDeviceConnected()
        {
            
            const string targetVid = "1234"; // Replace with your device's VID
            const string targetPid = "5678"; // Replace with your device's PID

            using var searcher = new ManagementObjectSearcher(@"Select * From Win32_PnPEntity Where DeviceID Like 'USB%'");
            foreach (ManagementObject device in searcher.Get())
            {
                _logger.LogInformation($"Found device {device}");
                var deviceId = device["DeviceID"]?.ToString();
                if (deviceId != null && deviceId.Contains($"VID_{targetVid}") && deviceId.Contains($"PID_{targetPid}"))
                {
                    // Device found
                    return true;
                }
            }
            return false;
        }
    }
}
