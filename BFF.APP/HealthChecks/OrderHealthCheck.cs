using BFF.APP.Services.Shopping.Clients.Interfaces;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BFF.APP.HealthChecks
{
    public class OrderHealthCheck : IHealthCheck
    {
        private readonly ILogger<OrderHealthCheck> _logger;
        private readonly IOrderClient _client;

        public OrderHealthCheck(
            ILogger<OrderHealthCheck> logger,
            IOrderClient client)
        {
            _logger = logger;
            _client = client;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var health = HealthCheckResult.Unhealthy();

            try
            {
                if (await _client.HealthCheckAsync())
                    health = HealthCheckResult.Healthy();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return health;
        }
    }
}
