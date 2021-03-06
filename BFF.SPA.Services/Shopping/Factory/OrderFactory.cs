﻿using BFF.SPA.Services.Shopping.Models;
using BFF.SPA.Services.Shopping.ViewModels;
using System.Linq;

namespace BFF.SPA.Services.Shopping.Factory
{
    public static class OrderFactory
    {
        public static ProductVM Create(Product entity)
        {
            return entity is object? new ProductVM
            {
                ShortDescription = entity.ShortDescription,
                SKU = entity.SKU
            } : default;
        }
        public static OrderItemVM Create(OrderItem entity)
        {
            return entity is object? new OrderItemVM
            {
                Price = entity.Price - entity.Discount,
                Quantity = entity.Quantity,
                Product = Create(entity.Product)
            } : default;
        }
        public static OrderVM Create(Order entity)
        {
            return entity is object? new OrderVM
            {
                Number = entity.Number,
                CustomerId = entity.CustomerId,
                Date = entity.Date,
                Items = entity.Items?.Where(p => p is object)?.Select(i => Create(i))?.ToList()
            } : default;
        }
    }
}
