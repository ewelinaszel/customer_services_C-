using CustomerServices.DataAccessLayer;
using CustomerServices.DataAccessLayer.Models;
using MediatR;

namespace CustomerServices
{
    public class AddCustomerHandler : IRequestHandler<AddCustomerCommand>
    {
        private readonly IContext _context;

        public AddCustomerHandler(IContext context)
        {
            _context = context;
        }

        public Task<Unit> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer(request.Name, request.Address, request.VatIdentyficationNumber, DateTime.Now);
            _context.Customers.Add(customer);
            _context.SaveChangesAsync();
            return Unit.Task;
            
        }
    }

    public record AddCustomerCommand(string Name, string VatIdentyficationNumber, string Address) : IRequest;
}
