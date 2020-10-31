using BFF.SPA.Services.Customers.Clients.Interfaces;
using System;
using System.Threading.Tasks;

namespace BFF.SPA.Service.Tests.Customer.Mocks
{
    public class CustomerClientFake : ICustomerClient
    {
        public Task<Services.Customers.Models.Customer> GetCustomerByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
