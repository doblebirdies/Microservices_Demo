using MediatR;

namespace ms.storage.application.Commands.Handlers
{
    public class PreparedProductCommandHandler : IRequestHandler<PreparedProductCommand, Unit>
    {
        public Task<Unit> Handle(PreparedProductCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Pedido preparado, crear servicio para llamar aquí y enviar notificación para avisar cliente en servicio shop");
            return Task.FromResult(Unit.Value);
            //simulamos la preparacion del pedido con Task.sleep(3000);
            //lanzamos producer para llamar a cola  ShippedProductevent  y a esta estará suscrito el método avisar cliente de shop.api que enviará correo a cliente
            //throw new NotImplementedException();
        }
    }
}
