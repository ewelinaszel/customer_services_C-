using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut(Name = "AddCustomer")]
        public async Task Post([FromBody] AddCustomerCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpDelete(Name ="DeleteCustomer")]
        public async Task Delete([FromBody] DeleteCustomerCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpPost(Name = "ChangeCustomerData")]
        public async Task Post([FromBody] ChangeCustomerDataCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpGet(Name = "ListCustomers")]
        public async Task<ListCustomersResult[]> Get()
        {
           return await _mediator.Send(new ListCustomersCommand());
        }
    }
}
