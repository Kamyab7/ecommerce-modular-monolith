using BuildingBlocks.Domain.Event;

namespace Customers.Features.Events;

public record CustomerCreatedDomainEvent(long Id, string Name) : IDomainEvent;
