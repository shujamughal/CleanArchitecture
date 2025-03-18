using Application.Features.Customer.Commands.CreateCustomer;
using Application.Features.Customer.Queries.GetAllCustomers;
using Application.Features.Customer.Queries.GetCustomerDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<List<CustomerDTO>> Get()
        {
            var query = new GetCustomersQuery();
            return await _mediator.Send(query);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<CustomerDetailsDTO> Get(int id)
        {
            var customerDetails = await _mediator.Send(new GetCustomerDetailsQuery(id));
            return customerDetails;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<ActionResult> Post(CreateCustomerCommand command)
        {
            var response = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = response }, response);
        }


        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
