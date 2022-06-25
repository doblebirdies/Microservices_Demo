using System.Text.Json;

namespace ms.communcations.rabbitmq.Events
{
    public class PreparedProductEvent : IRabbitMqEvent
    {
        public string Serialize() => JsonSerializer.Serialize(this);

        public Guid Id => Guid.NewGuid();
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Supplier { get; set; }

    }
}
