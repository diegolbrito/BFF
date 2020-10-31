using BFF.SPA.Services.Core.Services;
using BFF.SPA.Services.Customers.Clients.Interfaces;
using BFF.SPA.Services.Customers.Factory;
using BFF.SPA.Services.Shopping.Clients.Interfaces;
using BFF.SPA.Services.Shopping.Factory;
using BFF.SPA.Services.Shopping.Services.Interfaces;
using BFF.SPA.Services.Shopping.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace BFF.SPA.Services.Shopping.Services
{
    public class CustomerOrderService : ICustomerOrderService
    {
        private readonly ICustomerClient _customerClient;
        private readonly IOrderClient _orderClient;

        public CustomerOrderService(ICustomerClient customerClient, IOrderClient orderClient)
        {
            _customerClient = customerClient;
            _orderClient = orderClient;
        }
        public async Task<ServiceResponse<CustomerOrderListVM>> GetOrdersByCustomerAsync(string customerId)
        {
            var response = new ServiceResponse<CustomerOrderListVM>();

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
                Orders = orders?.Select(p => OrderFactory.Create(p))?.ToList(),
                Customer = CustomerFactory.Create(customer)
            };

            return response;
        }
    }
}
