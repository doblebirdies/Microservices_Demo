using MediatR;
using Microsoft.AspNetCore.Mvc;
using ms.shop.application.Commands;
using ms.shop.application.DTOs;
using ms.shop.application.Notifications;
using ms.shop.application.Queries;

namespace ms.shop.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost("[action]")]
        public async Task<ActionResult> CreateOrder([FromBody] OrderCreateDto order)
        {
            //Verificamos si hay stock con refit
            int a = 1; int b = 1;
            if (a == b)
            {                
                //Si NO hay stock
                await mediator.Publish(new OrderCanceledNotification(order.Email));
                //A su vez vamos a guardar el pedido pero con cantidad y precio 0
                //en email el texto "pedido cancelado por falta de stock" para poder verificar que ha funcionado
                order.Price = 0;
                order.Quantity = 0;
                order.Amount = 0;
                order.Email = "Pedido cancelado por falta de stock";
                await mediator.Send(new CreateOrderCommand(order));
                return Ok("Pedido cancelado por falta de stock");
            }
            else
                //Si hay stock
                return Ok(await mediator.Send(new CreateOrderCommand(order)));

        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrders() => Ok(await mediator.Send(new GetAllOrdersQuery()));

        [HttpGet("[action]/{id:int}")]
        public async Task<ActionResult<OrderDto>> GetOrderById(int id) => Ok(await mediator.Send(new GetOrderByIdQuery(id)));

        [HttpDelete("[action]/{id:int}")]
        public async Task<ActionResult> DeleteOrder(int id) => Ok(await mediator.Send(new DeleteOrderCommand(id)));

    }
}
