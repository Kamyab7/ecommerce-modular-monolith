using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Customers.Features.CreatingCustomer;

public class CreateCustomerEndpoint : EndpointBaseAsync
.WithRequest<CreateCustomerCommand>
.WithActionResult<long>
{
    private readonly IMediator _mediator;

    public CreateCustomerEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Create")]
    public override async Task<ActionResult<long>> HandleAsync([FromBody] CreateCustomerCommand request, CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(request);
    }
}