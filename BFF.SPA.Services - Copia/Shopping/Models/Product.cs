using BFF.SPA.Services.Core.Models;

namespace BFF.SPA.Services.Shopping.Models
{
    public class Product : Entity
    {
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string SKU { get; set; }
        public string EAN { get; set; }
    }
}
