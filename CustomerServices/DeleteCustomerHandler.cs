using CustomerServices.DataAccessLayer;
using MediatR;

namespace CustomerServices
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IContext _context;
        private readonly IMediator _mediator;

        public DeleteCustomerHandler(IContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerToDelete = _mediator.Send(new FindCustomerInDBCommand(request.vatIdentyficationNumber));
            _context.Customers.Remove(customerToDelete.Result);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
    public record DeleteCustomerCommand(string vatIdentyficationNumber) : IRequest;
}
