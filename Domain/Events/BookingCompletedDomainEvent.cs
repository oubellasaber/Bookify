using Bookify.Domain.Abstraction;

namespace Bookify.Domain.Events
{
    public sealed record BookingCompletedDomainEvent(Guid BookingId) : IDomainEvent;
}
