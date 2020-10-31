using BFF.SPA.Customers.Models;
using System.Threading.Tasks;

namespace BFF.SPA.Customers.Clients.Interfaces
{
    public interface ICustomerClient
    {
        Task<Customer> GetCustomerByIdAsync(string id);
    }
}
