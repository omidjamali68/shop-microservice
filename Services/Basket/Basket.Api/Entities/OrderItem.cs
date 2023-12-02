namespace Basket.Api.Entities
{
    public class OrderItem
    {
        public int Quantity { get; internal set; }
        public string Color { get; set; }
        public int Price { get; internal set; }
        public string ProductId { get; set; }
    }
}
