using BuildingBlocks.Domain.Model;
using Customers.Features.Events;

namespace Customers.Features.Models;

public class Customer : Aggregate<long>
{
    public string Name { get; private set; }

    public Customer(long id, string name)
    {
        Name = name;

        Id = id;

        var @event = new CustomerCreatedDomainEvent(Id, Name);

        this.AddDomainEvent(@event);
    }
}
