using Bookify.Domain.Abstraction;

namespace Bookify.Domain.Events
{
    public sealed record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;
}
