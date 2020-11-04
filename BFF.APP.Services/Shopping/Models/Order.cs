﻿using BFF.APP.Services.Core.Models;
using System;
using System.Collections.Generic;

namespace BFF.APP.Services.Shopping.Models
{
    public class Order : Entity
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public string CustomerId { get; set; }
        public string PromotionCode { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
