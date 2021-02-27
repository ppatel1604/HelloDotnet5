using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;

namespace HelloDotnet5
{
    public class ExternalEndpointHealthCheck : IHealthCheck
    {
        private readonly ServiceSettings _serviceSettings;

        public ExternalEndpointHealthCheck(IOptions<ServiceSettings> serviceSettingsOptions)
        {
            _serviceSettings = serviceSettingsOptions.Value;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            Ping ping = new();
            var response = await ping.SendPingAsync(_serviceSettings.OpenWeatherHost);

            return response.Status == IPStatus.Success ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy();
        }
    }
}