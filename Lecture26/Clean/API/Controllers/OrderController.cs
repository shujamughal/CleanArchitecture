using Application.Features.Order.Commands.CreateOrder;
using Application.Features.Order.Commands.DeleteOrder;
using Application.Features.Order.Commands.UpdateOrder;
using Application.Features.Order.Queries.GetAllOrders;
using Application.Features.Order.Queries.GetOrderDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public async Task<List<OrderDTO>> Get()
        {
            var query = new GetOrdersQuery();
            return await _mediator.Send(query);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<OrderDetailsDTO> Get(int id)
        {
            var orderDetails = await _mediator.Send(new GetOrderDetailsQuery(id));
            return orderDetails;
        }

        // POST api/<OrderController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(CreateOrderCommand command)
        {
            var response = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteOrderCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
