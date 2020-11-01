using BFF.SPA.Services.Customers.Clients.Interfaces;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BFF.SPA.HealthChecks
{
    public class CustomerHealthCheck : IHealthCheck
    {
        private readonly ILogger<CustomerHealthCheck> _logger;
        private readonly ICustomerClient _client;

        public CustomerHealthCheck(
            ILogger<CustomerHealthCheck> logger,
            ICustomerClient client)
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
