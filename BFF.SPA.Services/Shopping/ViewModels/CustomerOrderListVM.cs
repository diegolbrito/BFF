using System.Collections.Generic;
using System.Linq;

namespace BFF.SPA.Services.Shopping.ViewModels
{
    public class CustomerOrderListVM
    {
        public CustomerVM Customer { get; set; }
        public List<OrderVM> Orders { get; set; }
        public OrderVM LastOrder => Orders?.OrderByDescending(p => p.Date)?.FirstOrDefault();
    }
}
