using CustomerServices.DataAccessLayer;
using CustomerServices.DataAccessLayer.Models;
using MediatR;

namespace CustomerServices
{
    public class FindCustomerInDBHandler : IRequestHandler<FindCustomerInDBCommand, Customer>
    {
        private readonly IContext _context;

        public FindCustomerInDBHandler(IContext context)
        {
            _context = context;
        }

        public async Task<Customer> Handle(FindCustomerInDBCommand request, CancellationToken cancellationToken)
        {          
            return  _context.Customers.Single(customer => customer.VatIdentyficationNumber == request.VatIdentyficationNumber);
        }
    }
    public record FindCustomerInDBCommand(string VatIdentyficationNumber) : IRequest<Customer>;
}
