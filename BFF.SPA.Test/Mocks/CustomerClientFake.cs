using BFF.SPA.Services.Customers.Clients.Interfaces;
using System;
using System.Threading.Tasks;
using M = BFF.SPA.Services.Customers.Models;

namespace BFF.SPA.Test.Mocks
{
    public class CustomerClientFake : ICustomerClient
    {
        public Task<M.Customer> GetCustomerByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
