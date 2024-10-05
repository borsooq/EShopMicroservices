namespace Ordering.Domain.Events;

public record OrderUpdatedEvent(OrderAggregate order) : IDomainEvent;
