using BuildingBlocks.IdsGenerator;
using Customers.Features.Models;
using MediatR;

namespace Customers.Features.CreatingCustomer;

public record CreateCustomerCommand : IRequest<long>
{
    public long Id { get; set; } = SnowFlakIdGenerator.NewId();

    public string Name { get; set; }
}

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, long>
{
    public async Task<long> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer(request.Id, request.Name);

        await Task.Delay(25);

        return customer.Id;
    }
}
