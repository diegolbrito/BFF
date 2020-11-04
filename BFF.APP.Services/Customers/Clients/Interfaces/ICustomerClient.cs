using BFF.APP.Services.Customers.Models;
using System.Threading.Tasks;

namespace BFF.APP.Services.Customers.Clients.Interfaces
{
    public interface ICustomerClient
    {
        Task<Customer> GetCustomerByIdAsync(string id);
        Task<bool> HealthCheckAsync();
    }
}
