using BFF.SPA.Services.Customers.Clients.Interfaces;
using BFF.SPA.Services.Customers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BFF.SPA.Test.Customers.Mocks
{
    public class CustomerClientFake : ICustomerClient
    {
        #region Customers
        private static List<Customer> Customers = new List<Customer>
        {
            new Customer
            {
                Id = "8315a74c-9086-4fc3-863c-ff17d627b479",
                Name = "John",
                LastName = "Smith",
                BirthDate = new DateTime(1982, 11, 2),
                RegistrationDate = new DateTime(2020, 10, 31)
            }
        };
        #endregion
        public Task<Customer> GetCustomerByIdAsync(string id) => Task.FromResult(Customers.FirstOrDefault(p => p.Id == id));
    }
}
