namespace BFF.SPA.Shopping.ViewModels
{
    public class OrderItemVM
    {
        public ProductVM Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
