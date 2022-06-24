using MediatR;
using ms.shop.application.DTOs;

namespace ms.shop.application.Notifications
{
    public record OrderCanceledNotification(string email) : INotification;
    
}
