using System;
using System.Collections.Generic;

namespace BFF.APP.Services.Shopping.ViewModels
{
    public class OrderVM
    {
        public int Number { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public List<OrderItemVM> Items { get; set; }
    }
}
