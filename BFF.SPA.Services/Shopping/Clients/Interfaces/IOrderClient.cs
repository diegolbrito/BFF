using BFF.SPA.Services.Shopping.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BFF.SPA.Services.Shopping.Clients.Interfaces
{
    public interface IOrderClient
    {
        Task<List<Order>> GetOrdersByCustomerAsync(string customerId);
    }
}
