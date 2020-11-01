using BFF.SPA.Services.Shopping.Services;
using BFF.SPA.Services.Shopping.Services.Interfaces;
using BFF.SPA.Test.Customers.Mocks;
using BFF.SPA.Test.Shopping.Mocks;
using System.Linq;
using Xunit;

namespace BFF.SPA.Test.Shopping
{
    public class CustomerOrderServiceTest
    {
        private readonly ICustomerOrderService _service;
        public CustomerOrderServiceTest()
        {
            _service = new CustomerOrderService(new CustomerClientFake(), new OrderClientFake());
        }

        [Theory]
        [InlineData("8315a74c-9086-4fc3-863c-ff17d627b479")]
        public void GetOrdersByCustomerFound(string customerId)
        {
            var response = _service.GetOrdersByCustomerAsync(customerId).Result;
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data.Orders);
            Assert.True(response.Data.Orders.All(p => p.CustomerId == customerId));
        }

        [Theory]
        [InlineData("391e3ed4-22cc-4ec3-9930-54f51350d007")]
        public void GetOrdersByCustomerNotFound(string customerId)
        {
            var response = _service.GetOrdersByCustomerAsync(customerId).Result;
            Assert.NotNull(response);
            Assert.Null(response.Data);
        }
    }
}
