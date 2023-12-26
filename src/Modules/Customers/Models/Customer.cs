using BuildingBlocks.Domain.Event;
using BuildingBlocks.IdsGenerator;
using Customers.Features.Events;

namespace Customers.Models;

public class Customer : BaseAuditableEntity
{
    public string Name { get; private set; }

    public Customer(string name)
    {
        Name = name;

        Id = SnowFlakIdGenerator.NewId();

        var @event = new CustomerCreatedEvent(this);

        AddDomainEvent(@event);
    }
}
