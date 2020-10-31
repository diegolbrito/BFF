using BFF.SPA.Core.Services;
using BFF.SPA.Customers.Clients.Interfaces;
using BFF.SPA.Customers.Factory;
using BFF.SPA.Shopping.Clients.Interfaces;
using BFF.SPA.Shopping.Factory;
using BFF.SPA.Shopping.Services.Interfaces;
using BFF.SPA.Shopping.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace BFF.SPA.Shopping.Services
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
