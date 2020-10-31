using BFF.SPA.Core.Services;
using BFF.SPA.Shopping.ViewModels;
using System.Threading.Tasks;

namespace BFF.SPA.Shopping.Services.Interfaces
{
    public interface ICustomerOrderService
    {
        Task<ServiceResponse<CustomerOrderListVM>> GetOrdersByCustomerAsync(string customerId);
    }
}
