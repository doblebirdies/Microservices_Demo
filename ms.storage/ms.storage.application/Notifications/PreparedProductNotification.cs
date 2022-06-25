using MediatR;
using ms.storage.application.DTOs;

namespace ms.storage.application.Notifications
{
    public record PreparedProductNotification(ProductDto product) : INotification;
}
