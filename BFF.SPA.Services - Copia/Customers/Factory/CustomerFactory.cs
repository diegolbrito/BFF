using BFF.SPA.Services.Customers.Models;
using BFF.SPA.Services.Shopping.ViewModels;
using System;

namespace BFF.SPA.Services.Customers.Factory
{
    public static class CustomerFactory
    {
        public static CustomerVM Create(Customer entity)
        {
            return entity is object?  new CustomerVM
            {
                FullName = $"{entity?.Name} {entity.LastName}",
                Age = DateTime.UtcNow.Year - entity.BirthDate.Year
            } : default;
        }
    }
}
