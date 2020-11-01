using System.Threading.Tasks;
using BFF.SPA.Services.Core.Services;
using BFF.SPA.Services.Shopping.Services.Interfaces;
using BFF.SPA.Services.Shopping.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BFF.SPA.Shopping.Controllers
{
    [Route("v1/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ICustomerOrderService _service;

        public OrdersController(ICustomerOrderService service)
        {
            _service = service;
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ServiceResponse<CustomerOrderListVM>> GetOrdersByCustomerAsync(string customerId)
        {
            return await _service.GetOrdersByCustomerAsync(customerId);
        }
    }
}
