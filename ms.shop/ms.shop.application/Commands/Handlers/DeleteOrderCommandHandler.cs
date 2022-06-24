﻿using MediatR;
using ms.shop.application.DTOs;
using ms.shop.domain.Interfaces;

namespace ms.shop.application.Commands.Handlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IOrderRepository orderRepository;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        
        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            await orderRepository.DeleteAsync(request.id);
            return await orderRepository.SaveChangesAsync();            
        }


    }
}
