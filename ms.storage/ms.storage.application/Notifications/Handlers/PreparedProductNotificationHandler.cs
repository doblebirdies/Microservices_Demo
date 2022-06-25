using AutoMapper;
using MediatR;
using ms.communcations.rabbitmq.Events;
using ms.communcations.rabbitmq.Producers;

namespace ms.storage.application.Notifications.Handlers
{
    public class PreparedProductNotificationHandler : INotificationHandler<PreparedProductNotification>
    {        
        private readonly IProducer producer;
        private readonly IMapper mapper;

        public PreparedProductNotificationHandler(IProducer producer, IMapper mapper)
        {           
            this.producer = producer;
            this.mapper = mapper;
        }

        public Task Handle(PreparedProductNotification notification, CancellationToken cancellationToken)
        {                       
            producer.SendMessage(mapper.Map<PreparedProductEvent>(notification));
            return Task.CompletedTask;
        }
    }
}
