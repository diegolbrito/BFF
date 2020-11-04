using BFF.APP.Services.Customers.Models;
using BFF.APP.Services.Shopping.Models;
using BFF.APP.Services.Shopping.ViewModels;
using System.Linq;

namespace BFF.APP.Services.Shopping.Factory
{
    public static class OrderFactory
    {
        public static OrderItemVM Create(OrderItem entity)
        {
            return entity is object? new OrderItemVM
            {
                Quantity = entity.Quantity,
                ProductShortDescription = entity.Product?.ShortDescription
            } : default;
        }
        public static OrderVM Create(Order entity, Customer customer)
        {
            return entity is object? new OrderVM
            {
                Number = entity.Number,
                CustomerName = customer?.Name,
                Date = entity.Date,
                Items = entity.Items?.Where(p => p is object)?.Select(i => Create(i))?.ToList()
            } : default;
        }
    }
}
