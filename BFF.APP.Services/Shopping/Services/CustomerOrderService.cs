using BFF.APP.Services.Core.Services;
using BFF.APP.Services.Customers.Clients.Interfaces;
using BFF.APP.Services.Shopping.Clients.Interfaces;
using BFF.APP.Services.Shopping.Factory;
using BFF.APP.Services.Shopping.Services.Interfaces;
using BFF.APP.Services.Shopping.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BFF.APP.Services.Shopping.Services
{
    public class CustomerOrderService : ICustomerOrderService
    {
        private readonly ILogger<CustomerOrderService> _logger;
        private readonly ICustomerClient _customerClient;
        private readonly IOrderClient _orderClient;

        public CustomerOrderService(
            ILogger<CustomerOrderService> logger,
            ICustomerClient customerClient, 
            IOrderClient orderClient)
        {
            _logger = logger;
            _customerClient = customerClient;
            _orderClient = orderClient;
        }
        public async Task<ServiceResponse<CustomerOrderListVM>> GetOrdersByCustomerAsync(string customerId)
        {
            var response = new ServiceResponse<CustomerOrderListVM>();

            try
            {
                if (string.IsNullOrWhiteSpace(customerId))
                {
                    response.AddNotification("customerId is required");
                    return response;
                }

                var customer = await _customerClient.GetCustomerByIdAsync(customerId);
                var orders = await _orderClient.GetOrdersByCustomerAsync(customerId);

                if (customer is null)
                {
                    response.AddNotification($"customer {customerId} not found");
                    return response;
                }

                response.Data = new CustomerOrderListVM
                {
                    Orders = orders?.Select(p => OrderFactory.Create(p, customer))?.ToList()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.AddNotification("unexpected error");
            }

            return response;
        }
    }
}
