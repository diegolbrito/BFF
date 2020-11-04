using BFF.APP.Services.Shopping.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BFF.APP.Services.Shopping.Clients.Interfaces
{
    public interface IOrderClient
    {
        Task<List<Order>> GetOrdersByCustomerAsync(string customerId);
        Task<bool> HealthCheckAsync();
    }
}
