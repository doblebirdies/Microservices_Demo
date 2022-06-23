using MediatR;
using Microsoft.AspNetCore.Mvc;
using ms.shop.application.Commands;
using ms.shop.application.DTOs;
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
        public async Task<ActionResult> CreateOrder([FromBody]OrderCreateDto order) => Ok(await mediator.Send(new CreateOrderCommand(order)));

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAll() => Ok(await mediator.Send(new GetAllOrdersQuery()));

        [HttpGet("[action]/{id:int}")]
        public async Task<ActionResult<OrderDto>> GetById(int id) => Ok(await mediator.Send(new GetOrderByIdQuery(id)));


    }
}
