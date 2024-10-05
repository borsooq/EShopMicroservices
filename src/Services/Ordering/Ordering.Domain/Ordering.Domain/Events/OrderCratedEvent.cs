namespace Ordering.Domain.Events;

public record OrderCreatedEvent(OrderAggregate order) : IDomainEvent;
