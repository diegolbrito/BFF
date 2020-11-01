using BFF.SPA.Services.Shopping.Clients.Interfaces;
using BFF.SPA.Services.Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BFF.SPA.Test.Shopping.Mocks
{
    public class OrderClientFake : IOrderClient
    {
        #region Orders
        private static List<Order> Orders = new List<Order>
        {
            new Order
            {
                Id = "5e54740a-e075-42e2-8c94-e99c1f2e0a56",
                Number = 123,
                Date = new DateTime(2020, 10, 31),
                CustomerId = "8315a74c-9086-4fc3-863c-ff17d627b479",
                PromotionCode = "CDEL-UIPL",
                RegistrationDate = new DateTime(2020, 10, 31, 14, 42, 0),
                Items = new List<OrderItem>
                {
                    new OrderItem
                    {
                        Id = "ed46c3ad-8c10-4483-9f4f-7cd50d65cad6",
                        Price = 170m,
                        Discount = 5.49m,
                        Quantity = 2,
                        RegistrationDate = new DateTime(2020, 10, 31, 14, 42, 0),
                        Product = new Product
                        {
                            Id = "dd307311-a4c6-4b0e-8f48-3b09e323c1b8",
                            Description = "Phone Bluetooth s/ fio MX35",
                            ShortDescription = "Phone MX35",
                            EAN = "99398598538573589",
                            SKU = "12389",
                            RegistrationDate = new DateTime(2020, 10, 31, 14, 42, 0)
                        }
                    }
                }
            }
        };
        #endregion

        public Task<List<Order>> GetOrdersByCustomerAsync(string customerId) => Task.FromResult(Orders.Where(p => p.CustomerId == customerId).ToList());
    }
}
