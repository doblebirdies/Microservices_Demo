using MediatR;

namespace ms.storage.application.Commands
{
    public record PreparedProductCommand(string productName) : IRequest<bool>;   
}
