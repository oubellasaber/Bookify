using Bookify.Domain.Abstraction;

namespace Bookify.Domain.Events
{
    public sealed record BookingRejectedDomainEvent(Guid BookingId) : IDomainEvent;
}
