using Customers.Features.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Customers.Features.EventHandlers;

public class CustomerCreatedEventHandler : INotificationHandler<CustomerCreatedEvent>
{
    private readonly ILogger<CustomerCreatedEventHandler> _logger;

    public CustomerCreatedEventHandler(ILogger<CustomerCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Modular monolith Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
