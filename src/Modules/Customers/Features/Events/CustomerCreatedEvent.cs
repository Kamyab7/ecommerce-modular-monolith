using BuildingBlocks.Domain.Event;
using Customers.Models;

namespace Customers.Features.Events;

public class CustomerCreatedEvent : BaseEvent
{
    public CustomerCreatedEvent(Customer item)
    {
        Item = item;
    }

    public Customer Item { get; }
}
