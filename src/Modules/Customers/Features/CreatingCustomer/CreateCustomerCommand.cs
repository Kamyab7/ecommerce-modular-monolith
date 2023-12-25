using MediatR;

namespace Customers.Features.CreatingCustomer;

public record CreateCustomerCommand : IRequest<string>
{
    public string Name { get; set; }
}

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, string>
{
    public Task<string> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
