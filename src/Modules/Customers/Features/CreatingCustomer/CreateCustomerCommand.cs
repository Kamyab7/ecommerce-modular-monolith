using BuildingBlocks.IdsGenerator;
using Customers.Data;
using Customers.Models;
using MediatR;

namespace Customers.Features.CreatingCustomer;

public record CreateCustomerCommand(string Name) : IRequest<long>
{
    public long Id { get; set; } = SnowFlakIdGenerator.NewId();
}

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, long>
{
    private readonly CustomerDbContext _context;

    public CreateCustomerCommandHandler(CustomerDbContext context)
    {
        _context = context;
    }

    public async Task<long> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer(request.Id, request.Name);

        _context.Customers.Add(customer);

        await _context.SaveChangesAsync(cancellationToken);

        return customer.Id;
    }
}
