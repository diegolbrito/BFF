using BFF.SPA.Customers.Models;
using BFF.SPA.Shopping.ViewModels;
using System;

namespace BFF.SPA.Customers.Factory
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
