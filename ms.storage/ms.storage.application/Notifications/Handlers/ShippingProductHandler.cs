using AutoMapper;
using MediatR;
using ms.communications.rabbitmq.Producers;
using ms.communications.rabbitmq.Events;

namespace ms.storage.application.Notifications.Handlers
{
    public class ShippingProductHandler : INotificationHandler<PreparedProductNotification>
    {
        private readonly IMapper mapper;
        private readonly IProducer producer;

        public ShippingProductHandler(IMapper mapper, IProducer producer)
        {
            this.mapper = mapper;
            this.producer = producer;
        }

        public Task Handle(PreparedProductNotification notification, CancellationToken cancellationToken)
        {
            //Simulamos envío pedido
            Thread.Sleep(5000);
            //enviamos mensaje a cola para avisar de pedido enviado
            producer.SendMessage(mapper.Map<OrderShippedEvent>(notification.order));
            return Task.CompletedTask;
        }
    }
}
