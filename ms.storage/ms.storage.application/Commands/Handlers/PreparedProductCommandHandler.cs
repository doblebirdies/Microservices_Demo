using MediatR;

namespace ms.storage.application.Commands.Handlers
{
    public class PreparedProductCommandHandler : IRequestHandler<PreparedProductCommand, bool>
    {
        public Task<bool> Handle(PreparedProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
