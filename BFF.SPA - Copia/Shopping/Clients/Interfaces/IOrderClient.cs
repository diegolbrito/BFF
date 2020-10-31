using BFF.SPA.Shopping.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BFF.SPA.Shopping.Clients.Interfaces
{
    public interface IOrderClient
    {
        Task<List<Order>> GetOrdersByCustomerAsync(string customerId);
    }
}
