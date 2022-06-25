using AutoMapper;
using MediatR;
using ms.communcations.rabbitmq.Consumers;
using ms.communcations.rabbitmq.Events;
using ms.communications.rabbitmq.Events;
using ms.storage.application.Commands;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace ms.storage.api.Consumers
{
    public class ProductConsumer : IConsumer
    {
        private IConnection connection;
        private readonly IConfiguration configuration;
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public ProductConsumer(IConfiguration configuration, IMediator mediator, IMapper mapper)
        {
            this.configuration = configuration;
            this.mediator = mediator;
            this.mapper = mapper;
        }

        public void Unsubscribe() => connection?.Dispose();


        public void Subscribe()
        {


            o hay una forma genérica (que puede estar en el curso de udemy), o hay que crear un createproductconsumer y un preparedproductconsumer, es decir una clase para cada consumidor y añadirlos todos en el program como el actual


            var factory = new ConnectionFactory()
            {
                HostName = configuration.GetValue<string>("Communication:EventBus:HostName")
            };
            connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            var queue = typeof(OrderCreatedEvent).Name;

            channel.QueueDeclare(queue, durable: true, exclusive: false, autoDelete: false, null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += ReceivedEvent;

            channel.BasicConsume(queue: queue, autoAck: true, consumer: consumer);
        }

        private async void ReceivedEvent(object sender, BasicDeliverEventArgs e)
        {
            if (e.RoutingKey == typeof(OrderCreatedEvent).Name)
            {
                var message = Encoding.UTF8.GetString(e.Body.Span);
                var product = JsonSerializer.Deserialize<OrderCreatedEvent>(message);
                
                var result = await mediator.Send(new PreparedProductCommand(product.Product));
            }            
        }



    }
}
