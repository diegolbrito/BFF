using BFF.SPA.Services.Customers.Models;
using System.Threading.Tasks;

namespace BFF.SPA.Services.Customers.Clients.Interfaces
{
    public interface ICustomerClient
    {
        Task<Customer> GetCustomerByIdAsync(string id);
    }
}
