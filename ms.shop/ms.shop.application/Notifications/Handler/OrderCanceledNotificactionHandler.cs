using MediatR;
using ms.shop.application.Services;

namespace ms.shop.application.Notifications.Handler
{
    public class OrderCanceledNotificactionHandler : INotificationHandler<OrderCanceledNotification>
    {
        private readonly IEmailSender emailSender;

        public OrderCanceledNotificactionHandler(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        public Task Handle(OrderCanceledNotification notification, CancellationToken cancellationToken)
        {
            //Avisar cliente pedido cancelado
            emailSender.SendOrderCanceledEmail(notification.email);
            return Task.CompletedTask;
        }
    }
}
