using BFF.SPA.Services.Core.Services;
using BFF.SPA.Services.Shopping.ViewModels;
using System.Threading.Tasks;

namespace BFF.SPA.Services.Shopping.Services.Interfaces
{
    public interface ICustomerOrderService
    {
        Task<ServiceResponse<CustomerOrderListVM>> GetOrdersByCustomerAsync(string customerId);
    }
}
