using BFF.APP.Services.Core.Services;
using BFF.APP.Services.Shopping.ViewModels;
using System.Threading.Tasks;

namespace BFF.APP.Services.Shopping.Services.Interfaces
{
    public interface ICustomerOrderService
    {
        Task<ServiceResponse<CustomerOrderListVM>> GetOrdersByCustomerAsync(string customerId);
    }
}
