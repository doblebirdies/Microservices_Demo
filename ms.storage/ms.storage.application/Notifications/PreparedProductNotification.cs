using MediatR;
using ms.communications.rabbitmq.Events;

namespace ms.storage.application.Notifications
{
    public record PreparedProductNotification(OrderCreatedEvent order) : INotification;
}
