using AutoMapper;
using CustomerServices.DataAccessLayer;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomerServices
{
    public class ListCustomersHandler : IRequestHandler<ListCustomersCommand, ListCustomersResult[]>
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public ListCustomersHandler(IContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ListCustomersResult[]> Handle(ListCustomersCommand request, CancellationToken cancellationToken)
        {
            var listOfCustomers = await _context.Customers.ToArrayAsync();
            return _mapper.Map<ListCustomersResult[]>(listOfCustomers);
        }
    }
    public record ListCustomersCommand : IRequest<ListCustomersResult[]>;
    public class ListCustomersResult
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string VatIdentyficationNumber { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
