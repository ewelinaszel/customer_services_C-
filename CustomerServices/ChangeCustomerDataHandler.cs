using CustomerServices.DataAccessLayer;
using MediatR;

namespace CustomerServices
{
    public class ChangeCustomerDataHandler : IRequestHandler<ChangeCustomerDataCommand>
    {
        private readonly IMediator _mediator;
        private readonly IContext _context;

        public ChangeCustomerDataHandler(IMediator mediator, IContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<Unit> Handle(ChangeCustomerDataCommand request, CancellationToken cancellationToken)
        {
            var customerToChange = _mediator.Send(new FindCustomerInDBCommand(request.vatIdentyficationNumber));

            if ((customerToChange.Result.Name != request.name) && (request.name != "string"))
            {
                customerToChange.Result.Name = request.name;
                customerToChange.Result.CreationDate = DateTime.Now;
            }

            if ((customerToChange.Result.Address != request.address) && (request.address != "string"))
            {
                customerToChange.Result.Address = request.address;
                customerToChange.Result.CreationDate = DateTime.Now;
            }

            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
    public record ChangeCustomerDataCommand(string vatIdentyficationNumber, string name, string address) : IRequest;
}
