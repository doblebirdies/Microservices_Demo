﻿using ms.communcations.rabbitmq.Events;
using System.Text.Json;

namespace ms.communications.rabbitmq.Events
{
    public class OrderCreatedEvent : IRabbitMqEvent
    {
        public string Serialize() => JsonSerializer.Serialize(this);

        public Guid Id => Guid.NewGuid();
        public string Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public string Email { get; set; }
    }
}
