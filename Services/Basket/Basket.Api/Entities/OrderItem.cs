namespace Basket.Api.Entities
{
    public class OrderItem
    {
        public int Quantity { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public string ProductId { get; set; }
    }
}
