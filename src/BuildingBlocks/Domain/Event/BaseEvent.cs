using MediatR;

namespace BuildingBlocks.Domain.Event;

public abstract class BaseEvent : INotification
{
    public long Version { get; set; } = -1;

    public long Id { get; protected set; }
}
