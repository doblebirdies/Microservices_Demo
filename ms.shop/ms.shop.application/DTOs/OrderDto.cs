namespace ms.shop.application.DTOs
{
    public class OrderDto
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
