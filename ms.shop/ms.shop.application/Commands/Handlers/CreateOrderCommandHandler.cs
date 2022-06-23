using AutoMapper;
using MediatR;
using ms.shop.domain.Entities;
using ms.shop.domain.Interfaces;

namespace ms.shop.application.Commands.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            await orderRepository.AddAsync(mapper.Map<Order>(request.order));
            return await orderRepository.SaveChangesAsync();
        }
        
    }
}
